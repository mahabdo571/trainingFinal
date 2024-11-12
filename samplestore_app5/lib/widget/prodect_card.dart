import 'package:flutter/material.dart';
import 'package:samplestore_app5/constans.dart';
import 'package:samplestore_app5/models/prroduct.dart';

class ProdectCard extends StatelessWidget {
  const ProdectCard({
    super.key,
    required this.itemindex,
    required this.product,
    required this.press,
  });
  final int itemindex;
  final Product product;
  final Function press;

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    return Container(
      margin: const EdgeInsets.symmetric(
        vertical: kDefultPadding / 2,
        horizontal: kDefultPadding,
      ),
      height: 190,
      child: InkWell(
        onTap: () => press,
        child: Stack(
          alignment: Alignment.bottomCenter,
          children: [
            Container(
              height: 166,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(22),
                color: Colors.white,
                boxShadow: const [
                  BoxShadow(
                    offset: Offset(0, 2),
                    blurRadius: 25,
                    color: Colors.black26,
                  ),
                ],
              ),
            ),
            Positioned(
              top: 0,
              left: 0,
              child: Container(
                padding: const EdgeInsets.symmetric(
                  horizontal: kDefultPadding,
                ),
                height: 160,
                width: 200,
                child: Image.asset(
                  product.imageUrl,
                  fit: BoxFit.cover,
                ),
              ),
            ),
            Positioned(
              bottom: 0,
              right: 0,
              child: SizedBox(
                height: 136,
                width: size.width - 200,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: [
                    const Spacer(),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: kDefultPadding),
                      child: Text(
                        product.title,
                        style: Theme.of(context).textTheme.bodyLarge,
                      ),
                    ),
                    const Spacer(),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: kDefultPadding),
                      child: Text(
                        product.description,
                        style: Theme.of(context).textTheme.bodyMedium,
                      ),
                    ),
                    const Spacer(),
                    Padding(
                      padding: const EdgeInsets.all(kDefultPadding - 10),
                      child: Container(
                        padding: const EdgeInsets.symmetric(
                          horizontal: kDefultPadding * 1.5,
                          vertical: kDefultPadding / 5,
                        ),
                        decoration: BoxDecoration(
                          color: kScandryColor,
                          borderRadius: BorderRadius.circular(22),
                        ),
                        child: Text('price : ${product.price} \$'),
                      ),
                    ),
                  ],
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
