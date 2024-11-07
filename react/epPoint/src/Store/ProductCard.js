import React from "react";
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Button,
  Box,
  IconButton,
} from "@mui/material";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import DiscountIcon from "@mui/icons-material/LocalOffer";
import InventoryIcon from "@mui/icons-material/Inventory";
import DescriptionIcon from "@mui/icons-material/Description";
import { green, red } from "@mui/material/colors";
import { Helmet } from "react-helmet";

const ProductCard = ({ product }) => {
  const schemaMarkup = {
    "@context": "http://schema.org",
    "@type": "Product",
    name: product.productName,
    image: product.imageUrl,
    description: product.notes,
    offers: {
      "@type": "Offer",
      priceCurrency: "ILS",
      price: product.sellingPriceTradersPerPiece * 1.2,
      availability: "http://schema.org/InStock",
      url: window.location.href,
    },
  };

  return (
    <Card
      sx={{
        maxWidth: 345,
        margin: "auto",
        boxShadow: 4,
        borderRadius: 2,
        transition: "transform 0.2s",
        "&:hover": {
          transform: "scale(1.05)",
        },
      }}
    >
      <Helmet>
        <script type="application/ld+json">
          {JSON.stringify(schemaMarkup)}
        </script>
      </Helmet>
      <CardMedia
        component="img"
        height="200"
        image={
          product.imageUrl
            ? product.imageUrl
            : "https://via.placeholder.com/200"
        }
        alt={`صورة ${product.productName}`}
        sx={{ borderRadius: "4px 4px 0 0" }}
      />
      <CardContent sx={{ backgroundColor: "#f9f9f9", position: "relative" }}>
        <Typography
          variant="h6"
          component="div"
          gutterBottom
          sx={{ fontWeight: "bold", color: "#00796B" }}
        >
          {product.productName}
        </Typography>
        <Box sx={{ display: "flex", alignItems: "center", mb: 1 }}>
          <InventoryIcon sx={{ color: green[500], mr: 1 }} />
          <Typography variant="body2" color="text.secondary">
            الكمية المتوفرة: {product.quantityInStockPiece}
          </Typography>
        </Box>
        <Box sx={{ display: "flex", alignItems: "center", mb: 1 }}>
          <Typography
            variant="body2"
            color="text.secondary"
            sx={{ textDecoration: "line-through", mr: 1 }}
          >
            {product.sellingPricePerPiece * 1.2} شيكل
          </Typography>
          <DiscountIcon sx={{ color: red[500], mr: 1 }} />
          <Typography variant="body2" color="error">
            {product.sellingPriceTradersPerPiece * 1.2} شيكل
          </Typography>
        </Box>
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            position: "absolute",
            bottom: 8,
            left: 16,
          }}
        >
          <DescriptionIcon sx={{ color: "#00796B", mr: 1 }} />
          <Typography variant="body2" color="text.secondary">
            {product.notes}
          </Typography>
        </Box>
      </CardContent>
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          p: 2,
          backgroundColor: "#00796B",
        }}
      >
        <Button
          variant="contained"
          color="primary"
          startIcon={<AddShoppingCartIcon />}
          sx={{
            backgroundColor: green[600],
            "&:hover": {
              backgroundColor: green[700],
            },
          }}
        >
          أضف للسلة
        </Button>
      </Box>
    </Card>
  );
};

export default ProductCard;
