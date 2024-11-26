import 'package:flutter/material.dart';
import 'package:traveling_app7/screens/categories_screen.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:traveling_app7/screens/category_trips_screen.dart';
import 'package:traveling_app7/screens/filters_screen.dart';
import 'package:traveling_app7/screens/tabs_screen.dart';
import 'package:traveling_app7/screens/trip_detail_screen.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      localizationsDelegates: const [
        GlobalMaterialLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
      ],
      supportedLocales: const [
        Locale('ar', 'AE'), // English
      ],
      title: 'Traveling App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: Colors.white,
          secondary: Colors.amber,
        ),
        textTheme: ThemeData.light().textTheme.copyWith(
              headlineMedium: const TextStyle(
                color: Colors.blue,
                fontSize: 24,
                fontFamily: 'ElMessiri',
                fontWeight: FontWeight.bold,
              ),
              headlineLarge: const TextStyle(
                color: Colors.white,
                fontSize: 27,
                fontFamily: 'ElMessiri',
                fontWeight: FontWeight.bold,
              ),
              headlineSmall: const TextStyle(
                color: Colors.white,
                fontSize: 22,
                fontFamily: 'ElMessiri',
                fontWeight: FontWeight.bold,
              ),
            ),
        fontFamily: 'ElMessiri',
      ),
      initialRoute: '/',
      routes: {
        '/': (ctx) => const TabsScreen(),
        CategoryTripsScreen.screenRoute: (ctx) => CategoryTripsScreen(),
        TripDetailScreen.screenRoute: (ctx) => TripDetailScreen(),
        FiltersScreen.screenRoute: (ctx) => FiltersScreen(),
      },
    );
  }
}
