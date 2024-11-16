import 'package:chat_app6/screens/register_screen.dart';
import 'package:chat_app6/screens/signin_screen.dart';
import 'package:chat_app6/widgets/my_btn.dart';
import 'package:flutter/material.dart';

class WelcomeScreen extends StatefulWidget {
  static const screenRout = 'welcome_screen';
  const WelcomeScreen({super.key});

  @override
  State<WelcomeScreen> createState() => _WelcomeScreenState();
}

class _WelcomeScreenState extends State<WelcomeScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 24),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Column(
              children: [
                SizedBox(
                  height: 180,
                  child: Image.asset('images/logo.png'),
                ),
                const Text(
                  'Chat App',
                  style: TextStyle(
                    fontSize: 40,
                    fontWeight: FontWeight.w900,
                    color: Color(0xff2e386b),
                  ),
                ),
              ],
            ),
            const SizedBox(
              height: 30,
            ),
            MyBtn(
              color: Colors.yellow[900]!,
              title: 'Sign In',
              onPressed: () {
                Navigator.pushNamed(context, SignInScreen.screenRout);
              },
            ),
            MyBtn(
              color: Colors.blue[800]!,
              title: 'Register',
              onPressed: () {
                Navigator.pushNamed(context, RegisterScreen.screenRout);
              },
            ),
          ],
        ),
      ),
    );
  }
}
