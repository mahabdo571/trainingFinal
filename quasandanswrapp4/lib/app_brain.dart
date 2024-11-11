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
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يحتوي جسم الإنسان على الحديد؟',
        QustionImage: 'images/image-11.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الطيور تستطيع الطيران إلى القمر؟',
        QustionImage: 'images/image-12.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الكربوهيدرات مصدر للطاقة؟',
        QustionImage: 'images/image-13.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل تنمو النباتات من دون ضوء الشمس؟',
        QustionImage: 'images/image-14.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل يحتوي الزئبق على خصائص معدنية؟',
        QustionImage: 'images/image-15.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل القهوة تأتي من شجرة الكاكاو؟',
        QustionImage: 'images/image-16.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الزيت يطفو على سطح الماء؟',
        QustionImage: 'images/image-17.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل للكلاب القدرة على التذوق؟',
        QustionImage: 'images/image-18.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الصبار يحتاج إلى كمية كبيرة من الماء؟',
        QustionImage: 'images/image-19.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل يمكن للإنسان العيش في الفضاء دون بدلة فضاء؟',
        QustionImage: 'images/image-20.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل يتم تخزين الدهون في جسم الإنسان؟',
        QustionImage: 'images/image-21.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يتجمد الماء عند درجة 0 مئوية؟',
        QustionImage: 'images/image-22.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الفواكه تحتوي على سكريات طبيعية؟',
        QustionImage: 'images/image-23.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يمكن للإنسان أن يطير بدون مساعدة أدوات؟',
        QustionImage: 'images/image-24.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل للضوء سرعة ثابتة في الفراغ؟',
        QustionImage: 'images/image-25.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الزواحف قادرة على العيش في المياه؟',
        QustionImage: 'images/image-26.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل السكر يتكون من الكربون والأكسجين والهيدروجين؟',
        QustionImage: 'images/image-27.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل للشمس أطوار مثل القمر؟',
        QustionImage: 'images/image-28.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل يغطي الماء أكثر من 70% من سطح الأرض؟',
        QustionImage: 'images/image-29.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل القطط تضع البيض؟',
        QustionImage: 'images/image-30.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل يوجد للأشجار جذور؟',
        QustionImage: 'images/image-31.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يتنفس الإنسان الأكسجين؟',
        QustionImage: 'images/image-32.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل السمك يعيش على اليابسة؟',
        QustionImage: 'images/image-33.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الذئاب تعيش في مجموعات تسمى قطيع؟',
        QustionImage: 'images/image-34.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الفضاء يحتوي على هواء يمكن تنفسه؟',
        QustionImage: 'images/image-35.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الحديد أقوى من الألومنيوم؟',
        QustionImage: 'images/image-36.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل البطاطس فاكهة؟',
        QustionImage: 'images/image-37.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الكواكب تدور حول الشمس؟',
        QustionImage: 'images/image-38.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل للنباتات القدرة على إنتاج الغذاء بنفسها؟',
        QustionImage: 'images/image-39.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الإنسان يمتلك ذيل طويل؟',
        QustionImage: 'images/image-40.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الزرافة أطول حيوان بري؟',
        QustionImage: 'images/image-41.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل السمك يتنفس بواسطة الرئتين؟',
        QustionImage: 'images/image-42.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الدماغ هو العضو المسؤول عن التفكير؟',
        QustionImage: 'images/image-43.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الدلافين من الثدييات؟',
        QustionImage: 'images/image-44.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يمكن للإنسان رؤية الأشعة فوق البنفسجية؟',
        QustionImage: 'images/image-45.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل البرتقال يحتوي على فيتامين C؟',
        QustionImage: 'images/image-46.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الأسماك تعتبر من الزواحف؟',
        QustionImage: 'images/image-47.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل البشر ينمون شعر الرأس والأظافر باستمرار؟',
        QustionImage: 'images/image-48.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل للقمر تأثير على المد والجزر؟',
        QustionImage: 'images/image-49.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل البطريق طائر لا يطير؟',
        QustionImage: 'images/image-50.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل البرق يحدث بدون مطر؟',
        QustionImage: 'images/image-51.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل الفراشات من الثدييات؟',
        QustionImage: 'images/image-52.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الدم يحتوي على خلايا دم حمراء وبيضاء؟',
        QustionImage: 'images/image-53.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يمكن للنار أن تشتعل دون أوكسجين؟',
        QustionImage: 'images/image-54.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الحليب مصدر للكالسيوم؟',
        QustionImage: 'images/image-55.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل بإمكان النمل العيش تحت الأرض؟',
        QustionImage: 'images/image-56.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل يمكن للشمس أن تشرق من الغرب؟',
        QustionImage: 'images/image-57.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الزجاج موصل جيد للكهرباء؟',
        QustionImage: 'images/image-58.jpg',
        QustionAnswer: false),
    Qustion(
        QustinText: 'هل الزرافات تعيش في البرية؟',
        QustionImage: 'images/image-59.jpg',
        QustionAnswer: true),
    Qustion(
        QustinText: 'هل النسر يستطيع الطيران لارتفاعات عالية؟',
        QustionImage: 'images/image-60.jpg',
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
