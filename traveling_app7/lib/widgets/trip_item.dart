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

  String get getSeason {
    switch (season) {
      case Season.Autumn:
        return 'خريف';
      case Season.Winter:
        return 'شتاء';
      case Season.Summer:
        return 'صيف';
      case Season.Spring:
        return 'ربيع';
      default:
        return 'غير معرف';
    }
  }

  String get getTripType {
    switch (tripType) {
      case TripType.Exploration:
        return 'استكشاف';
      case TripType.Recovery:
        return 'نقاهة';
      case TripType.Activities:
        return 'انشطة';
      case TripType.Therapy:
        return 'معالجة';
      default:
        return 'غير معرف';
    }
  }

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
                Container(
                  height: 250,
                  alignment: Alignment.bottomRight,
                  padding: const EdgeInsets.symmetric(
                    vertical: 10,
                    horizontal: 20,
                  ),
                  decoration: BoxDecoration(
                    gradient: LinearGradient(
                        begin: Alignment.topCenter,
                        end: Alignment.bottomCenter,
                        colors: [
                          Colors.black.withOpacity(0),
                          Colors.black.withOpacity(0.8),
                        ],
                        stops: [
                          0.6,
                          1,
                        ]),
                  ),
                  child: Text(
                    title,
                    style: Theme.of(context).textTheme.headlineLarge,
                    overflow: TextOverflow.fade,
                  ),
                )
              ],
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Row(
                    children: [
                      Icon(
                        Icons.today,
                        color: Theme.of(context).colorScheme.primary,
                      ),
                      const SizedBox(
                        width: 6,
                      ),
                      Text(
                        '$duration يوم',
                      )
                    ],
                  ),
                  Row(
                    children: [
                      Icon(
                        Icons.wb_sunny,
                        color: Theme.of(context).colorScheme.primary,
                      ),
                      const SizedBox(
                        width: 6,
                      ),
                      Text(
                        getSeason,
                      )
                    ],
                  ),
                  Row(
                    children: [
                      Icon(
                        Icons.family_restroom,
                        color: Theme.of(context).colorScheme.primary,
                      ),
                      const SizedBox(
                        width: 6,
                      ),
                      Text(
                        getTripType,
                      )
                    ],
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
