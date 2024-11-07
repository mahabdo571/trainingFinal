import 'dart:math';

import 'package:flutter/material.dart';

void main() {
  runApp(MaterialApp(
    home: Scaffold(
      backgroundColor: Colors.indigo,
      appBar: AppBar(
        title: const Text(
          'تطابق الصور',
          style: TextStyle(color: Colors.white),
        ),
        backgroundColor: Colors.indigo[800],
      ),
      body: ImagePage(),
    ),
  ));
}

class ImagePage extends StatefulWidget {
  const ImagePage({super.key});

  @override
  State<ImagePage> createState() => _ImagePageState();
}

class _ImagePageState extends State<ImagePage> {
  int leftImage = Random().nextInt(8) + 1;
  int RightImage = Random().nextInt(8) + 1;
  int level = 0;
  void selectNum() {
    leftImage = Random().nextInt(8) + 1;
    RightImage = Random().nextInt(8) + 1;
  }

  String isWin() {
    if (leftImage == RightImage) {
      level++;
      return "لقد فزت";
    } else {
      return "حاول مرة اخرى ";
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Text(
          isWin(),
          style: TextStyle(fontSize: 42, color: Colors.white),
        ),
        Text(
          level.toString(),
          style: TextStyle(fontSize: 20, color: Colors.red),
        ),
        Padding(
          padding: const EdgeInsets.all(10),
          child: Row(
            children: [
              Expanded(
                child: TextButton(
                  onPressed: () {
                    setState(() {
                      selectNum();
                    });
                  },
                  child: Image.asset("images/image-$leftImage.png"),
                ),
              ),
              Expanded(
                child: TextButton(
                  onPressed: () {
                    setState(() {
                      selectNum();
                    });
                  },
                  child: Image.asset('images/image-$RightImage.png'),
                ),
              ),
            ],
          ),
        ),
      ],
    );
  }
}
