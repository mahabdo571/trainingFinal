import 'package:chat_app6/widgets/app_bar_customer.dart';
import 'package:chat_app6/widgets/message_stream_builder.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';

late User signedInUser;

class ChatScreen extends StatefulWidget {
  static const screenRout = 'chat_screen';
  const ChatScreen({super.key});

  @override
  State<ChatScreen> createState() => _ChatScreenState();
}

class _ChatScreenState extends State<ChatScreen> {
  final messageTextController = TextEditingController();
  final _fireStore = FirebaseFirestore.instance;
  final _auth = FirebaseAuth.instance;
  String? messageText;

  @override
  void initState() {
    super.initState();
    getCurrentUser();
  }

  void getCurrentUser() {
    try {
      final user = _auth.currentUser;
      if (user != null) {
        signedInUser = user;
        print(signedInUser.email);
      }
    } catch (e) {
      print(e);
    }
  }

  @override
  Widget build(BuildContext context) {
    final arguments = (ModalRoute.of(context)?.settings.arguments ??
        <dynamic, dynamic>{}) as Map;

    return Scaffold(
      appBar: AppBarCustomer(titleApp: 'Caht'),
      body: SafeArea(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            MessageStreamBuilder(fireStore: _fireStore, arguments: arguments),
            Container(
              decoration: const BoxDecoration(
                border: Border(
                  top: BorderSide(
                    color: Colors.orange,
                    width: 2,
                  ),
                ),
              ),
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Expanded(
                    child: TextField(
                      controller: messageTextController,
                      onChanged: (value) {
                        messageText = value;
                      },
                      decoration: const InputDecoration(
                        contentPadding: EdgeInsets.symmetric(
                          vertical: 10,
                          horizontal: 20,
                        ),
                        hintText: 'اكتب رسالتك هنا',
                        border: InputBorder.none,
                      ),
                    ),
                  ),
                  TextButton(
                    onPressed: () async {
                      messageTextController.clear();
                      final querySnapshot = await _fireStore
                          .collection('users')
                          .doc(arguments['currentUserDocId'])
                          .collection('rooms')
                          .where('SenderId', isEqualTo: _auth.currentUser?.uid)
                          .where('ReceiverId',
                              isEqualTo: arguments['ReceiverId'])
                          .get();
                      DocumentReference? roomRef;

                      if (querySnapshot.docs.isNotEmpty) {
                        // المستند موجود بالفعل
                        roomRef = querySnapshot.docs.first.reference;
                        roomRef.collection('messages').add({
                          'message': messageText,
                          'SenderId': _auth.currentUser?.uid,
                          'time': FieldValue.serverTimestamp(),
                        });
                      } else {
                        roomRef = await _fireStore
                            .collection('users')
                            .doc(arguments['currentUserDocId'])
                            .collection('rooms')
                            .add(
                          {
                            'SenderId': _auth.currentUser?.uid,
                            'ReceiverId': arguments['ReceiverId'],
                            'time': FieldValue.serverTimestamp(),
                          },
                        );
                      }

                      // messagesStreams();
                    },
                    child: Text(
                      'Send',
                      style: TextStyle(
                          color: Colors.blue[800],
                          fontWeight: FontWeight.bold,
                          fontSize: 18),
                    ),
                  )
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}











// import 'package:chat_app6/widgets/app_bar_customer.dart';
// import 'package:chat_app6/widgets/message_stream_builder.dart';
// import 'package:cloud_firestore/cloud_firestore.dart';
// import 'package:flutter/material.dart';
// import 'package:firebase_auth/firebase_auth.dart';

// late User signedInUser;

// class ChatScreen extends StatefulWidget {
//   static const screenRout = 'chat_screen';
//   const ChatScreen({super.key});

//   @override
//   State<ChatScreen> createState() => _ChatScreenState();
// }

// class _ChatScreenState extends State<ChatScreen> {
//   final messageTextController = TextEditingController();
//   final _fireStore = FirebaseFirestore.instance;
//   final _auth = FirebaseAuth.instance;
//   String? messageText;

//   @override
//   void initState() {
//     super.initState();
//     getCurrentUser();
//   }

//   void getCurrentUser() {
//     try {
//       final user = _auth.currentUser;
//       if (user != null) {
//         signedInUser = user;
//         print(signedInUser.email);
//       }
//     } catch (e) {
//       print(e);
//     }
//   }

//   @override
//   Widget build(BuildContext context) {
//     final arguments = (ModalRoute.of(context)?.settings.arguments ??
//         <dynamic, dynamic>{}) as Map;

//     print('ssssss ${arguments['data'].sender}');

//     return Scaffold(
//       appBar: AppBarCustomer(titleApp: 'Caht App'),
//       body: SafeArea(
//         child: Column(
//           mainAxisAlignment: MainAxisAlignment.spaceBetween,
//           crossAxisAlignment: CrossAxisAlignment.stretch,
//           children: [
//             MessageStreamBuilder(fireStore: _fireStore),
//             Container(
//               decoration: const BoxDecoration(
//                 border: Border(
//                   top: BorderSide(
//                     color: Colors.orange,
//                     width: 2,
//                   ),
//                 ),
//               ),
//               child: Row(
//                 crossAxisAlignment: CrossAxisAlignment.center,
//                 children: [
//                   Expanded(
//                     child: TextField(
//                       controller: messageTextController,
//                       onChanged: (value) {
//                         messageText = value;
//                       },
//                       decoration: const InputDecoration(
//                         contentPadding: EdgeInsets.symmetric(
//                           vertical: 10,
//                           horizontal: 20,
//                         ),
//                         hintText: 'اكتب رسالتك هنا',
//                         border: InputBorder.none,
//                       ),
//                     ),
//                   ),
//                   TextButton(
//                     onPressed: () async {
//                       messageTextController.clear();
//                       await _fireStore.collection('messages').add(
//                         {
//                           'text': messageText,
//                           'sender': signedInUser.email,
//                           'time': FieldValue.serverTimestamp(),
//                         },
//                       );

//                       // messagesStreams();
//                     },
//                     child: Text(
//                       'Send',
//                       style: TextStyle(
//                           color: Colors.blue[800],
//                           fontWeight: FontWeight.bold,
//                           fontSize: 18),
//                     ),
//                   )
//                 ],
//               ),
//             ),
//           ],
//         ),
//       ),
//     );
//   }
// }


