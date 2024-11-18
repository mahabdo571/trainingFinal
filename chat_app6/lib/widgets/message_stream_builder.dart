import 'package:chat_app6/screens/chat_screen.dart';
import 'package:chat_app6/widgets/message_line.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';

class MessageStreamBuilder extends StatefulWidget {
  const MessageStreamBuilder({
    super.key,
    required FirebaseFirestore fireStore,
    required this.arguments,
  }) : _fireStore = fireStore;
  final dynamic arguments;
  final FirebaseFirestore _fireStore;

  @override
  State<MessageStreamBuilder> createState() => _MessageStreamBuilderState();
}

class _MessageStreamBuilderState extends State<MessageStreamBuilder> {
  final _auth = FirebaseAuth.instance;

  late String? roomId='';

  void getIdDocUser() async {
    DocumentReference? roomRef;
    final querySnapshot = await widget._fireStore
        .collection('users')
        .doc(widget.arguments['currentUserDocId'])
        .collection('rooms')
        .where('SenderId', isEqualTo: _auth.currentUser?.uid)
        .where('ReceiverId', isEqualTo: widget.arguments['ReceiverId'])
        .get();

    if (querySnapshot.docs.isNotEmpty) {
      roomRef = querySnapshot.docs.first.reference;
      if (roomId == '') {
        setState(() {
          roomId = roomRef?.id;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    getIdDocUser();

   
    return StreamBuilder<QuerySnapshot>(
      stream: widget._fireStore
          .collection('users')
          .doc(widget.arguments['currentUserDocId'])
          .collection('rooms')
          .doc(roomId)
          .collection('messages')
          .orderBy('time')
          .snapshots(),
      builder: (context, snapshot) {
        List<MessageLine> messageWidgets = [];
        if (!snapshot.hasData) {
          print('no data');
        }
        final messages = snapshot.data!.docs.reversed;
        for (var message in messages) {
          final messageText = message.get('message');
          final sender = message.get('SenderId');
          Timestamp time = message.get('time');

          final messageWidget = MessageLine(
            text: messageText,
            sender: time.toDate().toString(),
            isMe: signedInUser.uid == sender,
          );
          messageWidgets.add(messageWidget);
        }

        return Expanded(
          child: ListView(
            reverse: true,
            padding: const EdgeInsets.symmetric(
              horizontal: 10,
              vertical: 20,
            ),
            children: messageWidgets,
          ),
        );
      },
    );
  }
}
