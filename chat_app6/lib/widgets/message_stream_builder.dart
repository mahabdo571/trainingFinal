import 'package:chat_app6/screens/chat_screen.dart';
import 'package:chat_app6/widgets/message_line.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';

class MessageStreamBuilder extends StatelessWidget {
  const MessageStreamBuilder({
    super.key,
    required FirebaseFirestore fireStore,
  }) : _fireStore = fireStore;

  final FirebaseFirestore _fireStore;

  @override
  Widget build(BuildContext context) {
    return StreamBuilder<QuerySnapshot>(
      stream: _fireStore.collection('messages').orderBy('time').snapshots(),
      builder: (context, snapshot) {
        List<MessageLine> messageWidgets = [];
        if (!snapshot.hasData) {
          print('no data');
        }
        final messages = snapshot.data!.docs.reversed;
        for (var message in messages) {
          final messageText = message.get('text');
          final sender = message.get('sender');

          final messageWidget = MessageLine(
            text: messageText,
            sender: sender,
            isMe: signedInUser.email == sender,
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
