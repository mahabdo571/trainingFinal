import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/widget/datails/datails_body.dart';

class DetailsScreen extends StatelessWidget {
  const DetailsScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: kPrimeryColor,
      appBar: detailsAppBar(context),
      body: DatailsBody(),
    );
  }

  AppBar detailsAppBar(BuildContext context) {
    return AppBar(
      backgroundColor: kBackgroundColor,
      elevation: 0,
      leading: IconButton(
        padding: const EdgeInsets.only(left: kDefultPadding),
        onPressed: () {
          Navigator.pop(context);
        },
        icon: const Icon(
          Icons.arrow_back,
        ),
        color: kPrimeryColor,
      ),
      centerTitle: false,
      title: Text(
        'رجوع',
        style: Theme.of(context).textTheme.bodyMedium,
      ),
    );
  }
}
