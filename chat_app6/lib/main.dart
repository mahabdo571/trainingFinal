import 'package:chat_app6/screens/chat_list.dart';
import 'package:chat_app6/screens/chat_screen.dart';
import 'package:chat_app6/screens/register_screen.dart';
import 'package:chat_app6/screens/signin_screen.dart';
import 'package:chat_app6/screens/welcome_screen.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'firebase_options.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );
  runApp(MainApp());
}

class MainApp extends StatelessWidget {
  MainApp({super.key});
  final _auth = FirebaseAuth.instance;

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ChatApp',
      // home: WelcomeScreen(),
      initialRoute: _auth.currentUser == null
          ? WelcomeScreen.screenRout
          : ChatList.screenRout,
      routes: {
        WelcomeScreen.screenRout: (w) => WelcomeScreen(),
        SignInScreen.screenRout: (s) => SignInScreen(),
        RegisterScreen.screenRout: (r) => RegisterScreen(),
        ChatScreen.screenRout: (c) => ChatScreen(),
        ChatList.screenRout: (c) => ChatList(),
      },
    );
  }
}
