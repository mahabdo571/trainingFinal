import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";

import AllProducts from "./Products/AllProducts";
import ProductList from "./Store/ProductList";
import Find from "./Orders/Find";
import StoreList from "./Store/StoreList";
import { Container, Grid, Box } from "@mui/material";

const App = () => {
  return (
    <Container maxWidth="xl">
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <Header />
        </Grid>
        <Grid item xs={12}>
          <Box sx={{ p: 2 }}>
            <Routes>
              <Route path="/" element={<StoreList  />} />
              <Route path="/Products" element={<AllProducts />} />
              <Route path="/orders" element={<Find  />} />
              <Route
                path="/cart"
                element={<Container sx={{ marginTop: 8 }}>cart Page</Container>}
              />
              <Route
                path="/setting"
                element={<Container sx={{ marginTop: 8 }}>setting Page</Container>}
              />
            </Routes>
          </Box>
        </Grid>

        <Grid item xs={12}>
          <Footer />
        </Grid>
      </Grid>
    </Container>
  );
};

export default App;
