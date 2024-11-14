import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/models/prroduct.dart';
import 'package:samplestore_app5/screens/details_screen.dart';
import 'package:samplestore_app5/widget/prodect_card.dart';

class HomeBody extends StatelessWidget {
  const HomeBody({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      bottom: false,
      child: Column(
        children: [
          const SizedBox(
            height: kDefultPadding / 2,
          ),
          Expanded(
            child: Stack(
              children: [
                Container(
                  margin: const EdgeInsets.only(top: 70),
                  decoration: const BoxDecoration(
                    color: kBackgroundColor,
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(20),
                      topRight: Radius.circular(20),
                    ),
                  ),
                ),
                ListView.builder(
                  itemCount: products.length,
                  itemBuilder: (context, index) => ProdectCard(
                    itemindex: index,
                    product: products[index],
                    press: () {
                       Navigator.push(
                        context,
                         MaterialPageRoute(
                          builder: (context) => DetailsScreen(
                            product: products[index],
                          ),
                          ),
                          );
                          
                          },
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
