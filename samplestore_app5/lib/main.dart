import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/screens/home_screen.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Store App ',
      theme: ThemeData(
        textTheme: GoogleFonts.almaraiTextTheme(Theme.of(context).textTheme),
        primaryColor: kPrimeryColor,
        colorScheme:
            ColorScheme.fromSwatch().copyWith(secondary: kScandryColor),
      ),
      home:const HomeScreen(),
    );
  }
}
