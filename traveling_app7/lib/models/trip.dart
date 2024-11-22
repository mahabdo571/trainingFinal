import 'package:flutter/material.dart';

import './season.dart';
import './trip_type.dart';

class Trip {
  final String id;
  final List<String> categories;
  final String title;
  final String imageUrl;
  final int duration;
  final TripType tripType;
  final Season season;
  final List<String> activities;
  final List<String> program;

  final bool isInSummer;
  final bool isInWinter;
  final bool isForFamilies;

  Trip(
      {required this.id,
      required this.categories,
      required this.title,
      required this.imageUrl,
      required this.activities,
      required this.program,
      required this.duration,
      required this.season,
      required this.tripType,
      required this.isInSummer,
      required this.isInWinter,
      required this.isForFamilies});
}
