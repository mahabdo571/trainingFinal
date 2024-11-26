import 'package:flutter/material.dart';
import 'package:traveling_app7/screens/categories_screen.dart';
import 'package:traveling_app7/screens/favorites_screen.dart';

class TabsScreen extends StatefulWidget {
  const TabsScreen({super.key});

  @override
  State<TabsScreen> createState() => _TabsScreenState();
}

class _TabsScreenState extends State<TabsScreen> {
  int _selectedScreenIndex = 0;
  final List<Widget> _screens = [
    CategoriesScreen(),
    FavoritesScreen(),
  ];
  void _selectScreen(int index) {
    setState(() {
      _selectedScreenIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.primary,
        title: Text(
          'دليل سياحي',
          style: Theme.of(context).textTheme.headlineLarge,
        ),
      ),
      body: _screens[_selectedScreenIndex],
      bottomNavigationBar: BottomNavigationBar(
        onTap: _selectScreen,
        backgroundColor: Theme.of(context).colorScheme.primary,
        selectedItemColor: Theme.of(context).colorScheme.secondary,
        unselectedItemColor: Colors.white,
        currentIndex: _selectedScreenIndex,
        items: [
          BottomNavigationBarItem(
            icon: Icon(Icons.dashboard),
            label: 'التصنيفات',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.star),
            label: 'المفضلة',
          ),
        ],
      ),
    );
  }
}















// import 'package:flutter/material.dart';
// import 'package:traveling_app7/screens/categories_screen.dart';
// import 'package:traveling_app7/screens/favorites_screen.dart';

// class TabsScreen extends StatelessWidget {
//   const TabsScreen({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return DefaultTabController(
//       length: 2,
//       child: Scaffold(
//         appBar: AppBar(
//           backgroundColor: Theme.of(context).colorScheme.primary,
//           title: const Text(
//             'دليل سياحي',
//             style: TextStyle(
//               color: Colors.white,
//             ),
//           ),
//           bottom: TabBar(
//             labelStyle: TextStyle(color: Colors.red),
//             unselectedLabelColor: Colors.white,
//             indicatorColor: Colors.red,
//             tabs: [
//               Tab(
//                 icon: Icon(
//                   Icons.dashboard,
//                   color: Colors.white,
//                 ),
//                 text: 'التصنيفات',
//               ),
//               Tab(
//                 icon: Icon(
//                   Icons.star,
//                   color: Colors.white,
//                 ),
//                 text: 'المفضلة',
//               ),
//             ],
//           ),
//         ),
//         body: TabBarView(
//           children: [
//             CategoriesScreen(),
//             FavoritesScreen(),
//           ],
//         ),
//       ),
//     );
//   }
// }
