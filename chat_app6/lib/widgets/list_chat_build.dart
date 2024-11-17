import 'package:chat_app6/screens/chat_screen.dart';
import 'package:chat_app6/widgets/message_line.dart';
import 'package:cloud_firestore/cloud_firestore.dart';

import 'package:flutter/material.dart';

class ListChatBuild extends StatelessWidget {
  final _fireStore = FirebaseFirestore.instance;

  ListChatBuild({
    super.key,
    required this.currentUserDocId,
  });

  final String currentUserDocId;

  @override
  Widget build(BuildContext context) {
    print('gfgfgfgfd-- $currentUserDocId');
    return StreamBuilder<QuerySnapshot>(
      stream: _fireStore
          .collection('users')
          .doc(currentUserDocId)
          //.doc('QGRXqze0xTkuQdivo5I4')
          .collection('Contacts')
          .snapshots(),
      builder: (context, snapshot) {
        List<MessageLine> messageWidgets = [];
        if (!snapshot.hasData) {
          print('no data');
        }
        final messages = snapshot.data!.docs.reversed;
        for (var message in messages) {
          final messageText = message.get('name');
          final userId = message.get('userId');
          //final sender = message.get('sender');

          final messageWidget = MessageLine(
            text: messageText,
            sender: userId,
            isMe: false,
          );
          messageWidgets.add(messageWidget);
        }

        return Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            SizedBox(
              height: 500,
              child: ListView.builder(
                itemCount: messageWidgets.length,
                itemBuilder: (context, index) {
                  return GestureDetector(
                    onTap: () {
                      Navigator.pushNamed(context, ChatScreen.screenRout,
                          arguments: {
                            'data': messageWidgets[index],
                            'currentUserDocId': currentUserDocId,
                            'ReceiverId': messageWidgets.first.sender,
                          });
                    },
                    child: ListTile(
                      leading: CircleAvatar(
                        backgroundColor: Colors.blue,
                        child: Text('ddddd'), // أول حرف من الاسم
                      ),
                      title: Text('${messageWidgets[index].text}'),
                      subtitle: Text('cccc'),
                    ),
                  );
                },
              ),
            ),
          ],
        );
      },
    );
  }
}
