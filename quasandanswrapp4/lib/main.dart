import 'package:flutter/material.dart';
import 'package:quasandanswrapp4/app_brain.dart';
import 'package:rflutter_alert/rflutter_alert.dart';

AppBrain appBrain = AppBrain();
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
  int coorectAnswer = 0;
  int wrngAnswer = 0;
  void CheckAnswer(bool whatUserPicked) {
    bool correctAnswer = appBrain.getAnswer();

    setState(() {
      if (whatUserPicked == correctAnswer) {
        answerResult.add(
          const Padding(
            padding: EdgeInsets.all(3.0),
            child: Icon(
              Icons.thumb_up,
              color: Colors.green,
            ),
          ),
        );
        coorectAnswer++;
      } else {
        answerResult.add(
          const Padding(
            padding: EdgeInsets.all(3.0),
            child: Icon(
              Icons.thumb_down,
              color: Colors.red,
            ),
          ),
        );
        wrngAnswer++;
      }

      appBrain.isFinshed() ? getAlartIfFinshed() : appBrain.nextQustion();
    });
  }

  void getAlartIfFinshed() {
    Alert(
      context: context,
      type: AlertType.info,
      title: "انتهت الاسئلة",
      desc: "لقد اجبت على $coorectAnswer اسئلة صحيحة و $wrngAnswer خطأ ",
      buttons: [
        DialogButton(
          child: Text(
            "ابدأ من جديد",
            style: TextStyle(color: Colors.white, fontSize: 20),
          ),
          onPressed: () {
            Navigator.pop(context);
          },
          width: 120,
        )
      ],
    ).show();
    appBrain.reset();
    answerResult = [];
    coorectAnswer = 0;
    wrngAnswer = 0;
  }

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
              Image.asset(appBrain.getImage()),
              const SizedBox(
                height: 20,
              ),
              Text(
                appBrain.getQustionText(),
                textAlign: TextAlign.center,
                style:
                    const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
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
                  CheckAnswer(true);
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
                  CheckAnswer(false);
                });
              },
            ),
          ),
        ),
      ],
    );
  }
}
