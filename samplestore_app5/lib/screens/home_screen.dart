import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/widget/home_body.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: kPrimeryColor,
      appBar: homeAppBar(),
      body: HomeBody(),
    );
  }

  AppBar homeAppBar() {
    return AppBar(
      elevation: 0,
      backgroundColor: kPrimeryColor,
      title: Text(
        'متجري',
        style: GoogleFonts.getFont('Almarai', color: kScandryColor),
      ),
      centerTitle: false,
      actions: [
        IconButton(
          icon: const Icon(Icons.menu),
          color: kScandryColor,
          onPressed: () {},
        ),
      ],
    );
  }
}
