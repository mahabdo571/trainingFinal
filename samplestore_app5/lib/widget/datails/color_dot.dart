import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';

class ColorDot extends StatelessWidget {
  const ColorDot({
    super.key,
    required this.fillColor,
    required this.isSelected,
  });

  final Color fillColor;
  final bool isSelected;
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.symmetric(
        horizontal: kDefultPadding / 2.5,
      ),
      padding: const EdgeInsets.all(3),
      height: 24,
      width: 24,
      decoration: BoxDecoration(
        shape: BoxShape.circle,
        border: Border.all(
            color: isSelected ? kTextLightColor : Colors.transparent),
      ),
      child: Container(
        decoration: BoxDecoration(shape: BoxShape.circle, color: fillColor),
      ),
    );
  }
}
