import 'package:flutter/material.dart';
import 'package:traveling_app7/screens/filters_screen.dart';

class AppDrawer extends StatelessWidget {
  const AppDrawer({super.key});

  ListTile bulidListTile(
      BuildContext ctx, String title, IconData icon, Function onTapClick) {
    return ListTile(
      leading: Icon(
        icon,
        size: 30,
        color: Colors.blue,
      ),
      title: Text(
        title,
        style: Theme.of(ctx).textTheme.headlineSmall,
      ),
      onTap: onTapClick(),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: Column(
        children: [
          Container(
            height: 100,
            width: double.infinity,
            padding: EdgeInsets.only(top: 10),
            alignment: Alignment.center,
            color: Theme.of(context).colorScheme.primary,
            child: Text(
              'دليلك السياحي',
              style: Theme.of(context).textTheme.headlineLarge,
            ),
          ),
          const SizedBox(
            height: 20,
          ),
          bulidListTile(
            context,
            'الرحلات',
            Icons.card_travel,
            () =>{
              Navigator.of(context).pushReplacementNamed(FiltersScreen.screenRoute)
            },
          ),
          bulidListTile(
            context,
            'التصفية',
            Icons.filter_list,
            ()=> {
              Navigator.of(context).pushReplacementNamed(FiltersScreen.screenRoute)
            },
          ),
        ],
      ),
    );
  }
}
