import 'package:flutter/material.dart';

void main() {
  runApp(ExamApp());
}

class ExamApp extends StatelessWidget {
  const ExamApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        backgroundColor: Colors.grey[300],
        appBar: AppBar(
          backgroundColor: Colors.grey,
          title: const Text("Exam"),
        ),
        body: const Padding(
          padding: EdgeInsets.all(20),
          child: ExamPage(),
        ),
      ),
    );
  }
}

class ExamPage extends StatefulWidget {
  const ExamPage({super.key});

  @override
  State<ExamPage> createState() => _ExamPageState();
}

class _ExamPageState extends State<ExamPage> {
  List<Padding> answerResult = [];
  List<String> question = [
    'q1',
    'q2',
    'q3',
    'q4',
  ];

  int questionNumber = 0;
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        Row(
          children: answerResult,
        ),
        Expanded(
          flex: 5,
          child: Column(
            children: [
              Image.asset('name'),
              const SizedBox(
                height: 20,
              ),
              Text(
                question[questionNumber],
                textAlign: TextAlign.center,
                style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ),
        Expanded(
          child: Padding(
            padding: const EdgeInsets.symmetric(vertical: 10),
            child: TextButton(
              style: TextButton.styleFrom(backgroundColor: Colors.indigo),
              child: const Text(
                'صح',
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 22,
                ),
              ),
              onPressed: () {
                setState(() {
                  questionNumber++.
                  ;
                  answerResult.add(
                    const Padding(
                      padding: EdgeInsets.all(3.0),
                      child: Icon(
                        Icons.thumb_up,
                        color: Colors.green,
                      ),
                    ),
                  );
                });
              },
            ),
          ),
        ),
        Expanded(
          child: Padding(
            padding: const EdgeInsets.symmetric(vertical: 10),
            child: TextButton(
              style: TextButton.styleFrom(backgroundColor: Colors.deepOrange),
              child: const Text(
                'خطأ',
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 22,
                ),
              ),
              onPressed: () {
                setState(() {
                  questionNumber++;
                  answerResult.add(
                    const Padding(
                      padding: EdgeInsets.all(3.0),
                      child: Icon(
                        Icons.thumb_down,
                        color: Colors.red,
                      ),
                    ),
                  );
                });
              },
            ),
          ),
        ),
      ],
    );
  }
}
