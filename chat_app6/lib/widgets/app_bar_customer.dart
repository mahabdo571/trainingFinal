import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';

class AppBarCustomer extends StatelessWidget implements PreferredSizeWidget {
  late String titleApp;
  final _auth = FirebaseAuth.instance;

  AppBarCustomer({required this.titleApp});

  @override
  Widget build(BuildContext context) {
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
            '$titleApp',
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
          },
          icon: const Icon(Icons.close),
        )
      ],
    );
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
