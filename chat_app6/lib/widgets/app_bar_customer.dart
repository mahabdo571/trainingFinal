import 'package:chat_app6/screens/welcome_screen.dart';
import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';

class AppBarCustomer extends StatelessWidget implements PreferredSizeWidget {
  late String titleApp;
  final _auth = FirebaseAuth.instance;

  AppBarCustomer({required this.titleApp});
  late String userEmail = '';

  @override
  Widget build(BuildContext context) {
    userEmail = '${_auth.currentUser?.email}';
    return AppBar(
      backgroundColor: Colors.yellow[900],
      title: Row(
        children: [
          Image.asset(
            'images/logo.png',
            height: 50,
          ),
          const SizedBox(
            width: 10,
          ),
          Text(
            '$titleApp  hi ${RegExp(r"^[^@]+").stringMatch(userEmail)}',
            style: const TextStyle(
              color: Colors.white,
              fontWeight: FontWeight.w900,
            ),
          ),
        ],
      ),
      actions: [
        IconButton(
          onPressed: () async {
            await _auth.signOut();
            Navigator.pop(context);
            Navigator.pushNamed(context, WelcomeScreen.screenRout);
          },
          icon: const Icon(Icons.exit_to_app),
        )
      ],
    );
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
