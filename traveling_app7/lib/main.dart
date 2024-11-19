import 'package:flutter/material.dart';
import 'package:traveling_app7/screens/categories_screen.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Traveling App',
      home: CategoriesScreen(),
    );
  }
}
