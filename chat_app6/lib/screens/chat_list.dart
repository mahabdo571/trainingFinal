import 'package:chat_app6/widgets/app_bar_customer.dart';
import 'package:chat_app6/widgets/list_chat_build.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';

class ChatList extends StatefulWidget {
  const ChatList({super.key});
  static const screenRout = 'chat_list';

  @override
  State<ChatList> createState() => _ChatListState();
}

class _ChatListState extends State<ChatList> {
  final _fireStore = FirebaseFirestore.instance;
  final _auth = FirebaseAuth.instance;
  late String currentUserDocId = '';
  void _showCustomDialog(BuildContext context) {
    late String inputEmail = '';
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return Dialog(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(15.0),
          ),
          child: Container(
            padding: EdgeInsets.all(20),
            height: 300,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text(
                  'اضافة',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                ),
                const SizedBox(height: 20),
                const Text('قم بالبحث عن شخص لاضافته لبدء المحادثة معه'),
                const SizedBox(height: 20),
                TextField(
                  onChanged: (va) {
                    inputEmail = va;
                  },
                  decoration: const InputDecoration(
                    hintText: 'ادخل الايميل للبحث',
                    contentPadding:
                        EdgeInsets.symmetric(vertical: 10, horizontal: 20),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.all(
                        Radius.circular(10),
                      ),
                    ),
                    enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.orange, width: 1),
                      borderRadius: BorderRadius.all(
                        Radius.circular(10),
                      ),
                    ),
                    focusedBorder: OutlineInputBorder(
                      borderSide: BorderSide(color: Colors.blue, width: 2),
                      borderRadius: BorderRadius.all(
                        Radius.circular(10),
                      ),
                    ),
                  ),
                ),
                Row(
                  children: [
                    ElevatedButton(
                      onPressed: () {
                        Navigator.of(context).pop(); // إغلاق النافذة
                      },
                      child: const Text('اغلاق'),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        searchUserByEmail(inputEmail);
                        Navigator.of(context).pop(); // إغلاق النافذة
                      },
                      child: const Text('اضافة'),
                    ),
                  ],
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  void _searchEmailifAdd(String userId, var data) async {
    try {
      final querySnapshot = await _fireStore
          .collection('users')
          .doc(await getIdDocCurrentUser())
          .collection('Contacts')
          .where('userId', isEqualTo: userId)
          .get();
      if (querySnapshot.docs.isEmpty) {
        _addFrind(data);
      } else {
        print('email added $userId');
      }
    } catch (e) {
      print(e);
    }
  }

  void searchUserByEmail(String email) async {
    if (email != _auth.currentUser?.email) {
      try {
        final querySnapshot = await _fireStore
            .collection('users')
            .where('email', isEqualTo: email)
            .get();

        if (querySnapshot.docs.isNotEmpty) {
          _searchEmailifAdd(
              querySnapshot.docs[0].data()['userId'], querySnapshot.docs[0]);
        } else {
          print('No user found with email: $email');
        }
      } catch (e) {
        print('Error occurred: $e');
      }
    } else {
      print('لا يمكن اضافة نفسك');
    }
  }

  void _addFrind(var data) async {
    await _fireStore
        .collection('users')
        .doc(await getIdDocCurrentUser())
        .collection('Contacts')
        .add({
      'userId': data.data()['userId'],
      'name': data.data()['name'],
      'image': data.data()['image'],
    });
  }

  Future<String> getIdDocCurrentUser() async {
    try {
      final querySnapshot = await _fireStore
          .collection('users')
          .where('email', isEqualTo: _auth.currentUser?.email)
          .get();

      if (querySnapshot.docs.isNotEmpty) {
        if (currentUserDocId.isEmpty) {
          setState(() {
            currentUserDocId = querySnapshot.docs[0].id;
          });
        }
        return querySnapshot.docs[0].id;
      }
    } catch (e) {
      print('Error occurred: $e');
      return "";
    }
    return "";
  }

  @override
  Widget build(BuildContext context) {
    getIdDocCurrentUser();

    return Scaffold(
      appBar: AppBarCustomer(titleApp: 'Chats'),
      body: SafeArea(
        child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              ListChatBuild(
                currentUserDocId: currentUserDocId,
              ),
            ]),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          // الإجراء عند الضغط على الزر
          _showCustomDialog(context);
        },
        backgroundColor: Colors.green,
        child: Icon(Icons.message, color: Colors.white),
      ),
      bottomNavigationBar: BottomNavigationBar(
        onTap: (va) {},
        items: [
          BottomNavigationBarItem(
            icon: Icon(Icons.chat),
            label: 'الدردشات',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.people),
            label: 'جهات الاتصال',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.account_box_rounded),
            label: 'الملف الشخصي',
          ),
        ],
      ),
    );
  }
}
