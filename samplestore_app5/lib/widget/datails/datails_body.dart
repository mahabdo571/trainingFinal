import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';

class DatailsBody extends StatelessWidget {
  const DatailsBody({super.key});

  @override
  Widget build(BuildContext context) {
    Size saiz = MediaQuery.of(context).size;
    return Column(
      children: [
        Container(
          padding: const EdgeInsets.symmetric(horizontal: kDefaultFontSize),
         // height: 400,
          decoration: const BoxDecoration(
            color: kBackgroundColor,
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(50),
              bottomRight: Radius.circular(50),
            ),
          ),
          child: Column(
            children: [
              Container(
                margin: const EdgeInsets.symmetric(vertical: kDefaultFontSize),
                height: saiz.width * 0.8,
                color: const Color.fromARGB(255, 63, 249, 196),
              ),
            ],
          ),
        ),
      ],
    );
  }
}
