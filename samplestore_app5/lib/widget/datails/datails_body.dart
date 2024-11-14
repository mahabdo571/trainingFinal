import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/models/prroduct.dart';
import 'package:samplestore_app5/widget/datails/color_dot.dart';
import 'package:samplestore_app5/widget/datails/product_image.dart';

class DatailsBody extends StatelessWidget {
  const DatailsBody({super.key, required this.product});

  final Product product;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Container(
          width: double.infinity,
          padding: const EdgeInsets.symmetric(
            horizontal: kDefultPadding * 1.5,
          ),
          // height: 400,
          decoration: const BoxDecoration(
            color: kBackgroundColor,
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(50),
              bottomRight: Radius.circular(50),
            ),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Center(
                child: ProductImage(
                  size: size,
                  image: product.imageUrl,
                ),
              ),
              const Padding(
                padding: EdgeInsets.symmetric(vertical: kDefultPadding),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    ColorDot(
                      fillColor: kTextLightColor,
                      isSelected: false,
                    ),
                    ColorDot(
                      fillColor: kBlueColor,
                      isSelected: true,
                    ),
                    ColorDot(
                      fillColor: Colors.red,
                      isSelected: false,
                    ),
                  ],
                ),
              ),
              Padding(
                padding:
                    const EdgeInsets.symmetric(vertical: kDefultPadding / 2),
                child: Text(
                  product.title,
                  style: Theme.of(context).textTheme.bodyLarge,
                ),
              ),
              Text(
                'price ${product.price}\$',
                style: const TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.w600,
                  color: kScandryColor,
                ),
              ),
              const SizedBox(
                height: kDefultPadding,
              ),
            ],
          ),
        ),
        Container(
          margin: const EdgeInsets.symmetric(vertical: kDefultPadding / 2),
          padding: const EdgeInsets.symmetric(
            horizontal: kDefultPadding * 1.5,
            vertical: kDefultPadding / 2,
          ),
          child: Text(
            product.description,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 19,
            ),
          ),
        ),
      ],
    );
  }
}
