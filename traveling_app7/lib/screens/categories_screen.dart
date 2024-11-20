import 'package:flutter/material.dart';
import 'package:traveling_app7/widgets/category_item.dart';
import 'package:traveling_app7/app_data.dart';

class CategoriesScreen extends StatelessWidget {
  const CategoriesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.primary,
        title: const Text(
          'دليل سياحي',
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: GridView(
        padding: EdgeInsets.all(10),
        gridDelegate: const SliverGridDelegateWithMaxCrossAxisExtent(
          maxCrossAxisExtent: 200,
          childAspectRatio: 7 / 8,
          mainAxisSpacing: 10,
          crossAxisSpacing: 10,
        ),
        children: Categories_data.map(
          (categoryData) => CategoryItem(
            title: categoryData.title,
            imageUrl: categoryData.imageUrl,
            id: categoryData.id,
          ),
        ).toList(),
      ),
    );
  }
}
