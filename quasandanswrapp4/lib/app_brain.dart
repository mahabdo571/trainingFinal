import 'dart:collection';

import 'package:quasandanswrapp4/qustion.dart';

class AppBrain {
  int _questionNumber = 0;
  final List<Qustion> _listQustion = [
    Qustion(
        QustinText: 'هل الماء ضروري للحياة؟',
        QustionImage: 'images/image-1.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الشمس تدور حول الأرض؟',
        QustionImage: 'images/image-2.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الفيل أكبر من القطة؟',
        QustionImage: 'images/image-3.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الطماطم فاكهة؟',
        QustionImage: 'images/image-4.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يمكن للبشر العيش دون أكسجين؟',
        QustionImage: 'images/image-5.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الجبال تتكون نتيجة نشاطات بركانية؟',
        QustionImage: 'images/image-6.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الماء يغلي عند درجة 100 مئوية؟',
        QustionImage: 'images/image-7.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الأرض مسطحة؟',
        QustionImage: 'images/image-8.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الخفاش طائر؟',
        QustionImage: 'images/image-9.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الإنسان يمتلك 206 عظمة في جسمه؟',
        QustionImage: 'images/image-10.jpg',
        QustionAnswer: true)
  ];

  void nextQustion() {
    if (_questionNumber < _listQustion.length - 1) {
      _questionNumber++;
    }
  }

  String getImage() {
    return _listQustion[_questionNumber].questionImage;
  }

  String getQustionText() {
    return _listQustion[_questionNumber].qustionText;
  }

  bool getAnswer() {
    return _listQustion[_questionNumber].qustionAnswer;
  }

  bool isFinshed() {
    return _questionNumber >= _listQustion.length - 1;
  }

  void reset() {
    _questionNumber = 0;
  }

  int getNumberOfQustion() {
    return _listQustion.length;
  }
}
