import React, { useState, useEffect } from "react";
import { Container, Grid } from "@mui/material";
import ProductCard from "./ProductCard"; // افترض أن الكود السابق في مكون ProductCard

import axios from "axios";
import { API_URL, API_Sales, API_Products, API_Orders } from "../API/API";

const StoreList = () => {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`${API_URL}/${API_Products}`);
        setData(response.data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []); // التأثير الفارغ [] يعني أن useEffect سيتم استدعاؤه مرة واحدة عند تحميل المكون

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <Container maxWidth="lg" sx={{ mt: 4, marginTop: 20 }}>
      <Grid container spacing={4}>
        {data.map((product) => (
          <Grid item xs={12} sm={6} md={4} key={product.productID}>
            <ProductCard product={product} />
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default StoreList;
