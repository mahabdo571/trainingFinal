import 'package:flutter/material.dart';
import 'package:traveling_app7/models/season.dart';
import 'package:traveling_app7/models/trip_type.dart';

class TripItem extends StatelessWidget {
  const TripItem(
      {super.key,
      required this.title,
      required this.imageUrl,
      required this.duration,
      required this.tripType,
      required this.season});

  final String title;
  final String imageUrl;
  final int duration;
  final TripType tripType;
  final Season season;

  void selectTrip() {}
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: selectTrip,
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(15),
        ),
        elevation: 7,
        margin: const EdgeInsets.all(10),
        child: Column(
          children: [
            Stack(
              children: [
                ClipRRect(
                  borderRadius: const BorderRadius.only(
                    topLeft: Radius.circular(15),
                    topRight: Radius.circular(15),
                  ),
                  child: Image.network(
                    imageUrl,
                    height: 250,
                    width: double.infinity,
                    fit: BoxFit.cover,
                  ),
                ),
              ],
            )
          ],
        ),
      ),
    );
  }
}
