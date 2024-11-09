import 'package:flutter/material.dart';
import 'package:audioplayers/audioplayers.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  void playMusic(int numberMusic) {
    final player = AudioPlayer();
    player.play(AssetSource('music-$numberMusic.mp3'));
  }

  Expanded myButton(int musicNumber, Color buttonColor, String buttonText) {
    return Expanded(
      child: Padding(
        padding: const EdgeInsets.only(bottom: 2),
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(
              backgroundColor: const Color.fromARGB(255, 238, 226, 158)),
          onPressed: () {
            playMusic(musicNumber);
          },
          child: Padding(
            padding: const EdgeInsets.only(left: 20),
            child: Row(
              children: [
                Icon(
                  Icons.music_note,
                  color: buttonColor,
                ),
                SizedBox(
                  width: 20,
                ),
                Text(
                  buttonText,
                  style: TextStyle(
                    color: buttonColor,
                    fontSize: 32,
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: SafeArea(
        child: Scaffold(
          backgroundColor: Colors.purple[300],
          appBar: AppBar(
            backgroundColor: Colors.purple,
            title: Text("Naghamat"),
          ),
          body: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              myButton(1, Colors.red, 'iphone'),
              myButton(2, Colors.green, 'nokia'),
              myButton(3, Colors.blue, 'samsoung'),
              myButton(4, Colors.black, 'opoo'),
              myButton(5, Colors.deepOrange, 'mi'),
              myButton(6, Colors.orange, 'moto'),
              myButton(7, Colors.pink, 'ercson'),
            ],
          ),
        ),
      ),
    );
  }
}
