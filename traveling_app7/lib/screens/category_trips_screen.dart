import 'package:flutter/material.dart';

class CategoryTripsScreen extends StatelessWidget {
  const CategoryTripsScreen(
      {super.key, required this.categoryId, required this.CategoryTitle});

  final String categoryId;
  final String CategoryTitle;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          CategoryTitle,
          style: TextStyle(color: Colors.white),
        ),
        backgroundColor: Theme.of(context).colorScheme.primary,
      ),
      body: Center(
        child: Text('teeeeeest'),
      ),
    );
  }
}
