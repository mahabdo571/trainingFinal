import React, { useState, useRef, useEffect } from "react";
import moment from "moment";
import useSWR from "swr";
import axios from "axios";
import { Card, CardContent, Grid } from "@mui/material";
import {
  CalendarToday as CalendarTodayIcon,
  AttachMoney as AttachMoneyIcon,
  ConfirmationNumber as ConfirmationNumberIcon,
  ShoppingCart as ShoppingCartIcon,
  Payment as PaymentIcon,
  CurrencyExchange as CurrencyExchangeIcon,
  LocalAtm as LocalAtmIcon,
  Receipt as ReceiptIcon,
  Discount as DiscountIcon,
} from "@mui/icons-material";

import {
  Alert,
  Container,
  Typography,
  TextField,
  Paper,
  Box,
} from "@mui/material";

import ListItem from "./ListItem";

import { API_URL, API_Sales, API_Products, API_Orders } from "../API/API";
const fetcher = (url) => axios.get(url).then((res) => res.data);

const Find = () => {
  const [searchQuery, setSearchQuery] = useState("");

  const { data, error, mutate } = useSWR(
    `${API_URL}/${API_Orders}/${searchQuery}`,
    fetcher
  );

  useEffect(() => {
    setSearchQuery(
      sessionStorage.getItem("SS_CurrentOrderID")
        ? sessionStorage.getItem("SS_CurrentOrderID")
        : ""
    );
  }, []);
  const textFieldRef = useRef(null);

  const handleSearchChange = (event) => {
    setSearchQuery(event.target.value);
    mutate();
  };

  if (searchQuery !== "" && error && error.response.status === 400) {
    if (textFieldRef.current) {
      textFieldRef.current.focus();
    }
    return (
      <Container sx={{ marginTop: 8 }}>
        <Typography variant="h4" gutterBottom>
          البحث عن طلبية
        </Typography>
        <Alert severity="error" sx={{ mt: 4 }}>
          الرجاء كتابة ارقام فقط
        </Alert>
        <Paper elevation={3} sx={{ padding: 2, marginBottom: 4 }}>
          <TextField
            fullWidth
            label="بحث"
            inputRef={textFieldRef}
            variant="outlined"
            value={searchQuery}
            onChange={handleSearchChange}
            sx={{ marginBottom: 2 }}
          />
        </Paper>
      </Container>
    );
  }
  if (searchQuery !== "" && error && error.response.status === 404) {
    if (textFieldRef.current) {
      textFieldRef.current.focus();
    }
    return (
      <Container sx={{ marginTop: 8 }}>
        <Typography variant="h4" gutterBottom>
          البحث عن طلبية
        </Typography>
        <Alert severity="error" sx={{ mt: 4 }}>
          الطلبية غير موجودة
        </Alert>
        <Paper elevation={3} sx={{ padding: 2, marginBottom: 4 }}>
          <TextField
            fullWidth
            label="بحث"
            inputRef={textFieldRef}
            variant="outlined"
            value={searchQuery}
            onChange={handleSearchChange}
            sx={{ marginBottom: 2 }}
          />
        </Paper>
      </Container>
    );
  }
  if (searchQuery !== "" && !data) {
    if (textFieldRef.current) {
      textFieldRef.current.focus();
    }
    return (
      <Container sx={{ marginTop: 8 }}>
        <Typography variant="h4" gutterBottom>
          البحث عن طلبية
        </Typography>
        <Alert severity="info" sx={{ mt: 4 }}>
          جار البحث
        </Alert>
        <Paper elevation={3} sx={{ padding: 2, marginBottom: 4 }}>
          <TextField
            fullWidth
            label="بحث"
            inputRef={textFieldRef}
            variant="outlined"
            value={searchQuery}
            onChange={handleSearchChange}
            sx={{ marginBottom: 2 }}
          />
        </Paper>
      </Container>
    );
  }

  console.log(data);
  return (
    <Container sx={{ marginTop: 8 }}>
      <Typography variant="h4" gutterBottom>
        البحث عن طلبية
      </Typography>

      <Paper elevation={3} sx={{ padding: 2, marginBottom: 4 }}>
        <TextField
          fullWidth
          label="بحث"
          inputRef={textFieldRef}
          variant="outlined"
          value={searchQuery}
          onChange={handleSearchChange}
          sx={{ marginBottom: 2 }}
        />
      </Paper>
      {data && (
        <>
          <Card style={{ margin: "20px", padding: "20px" }}>
            <CardContent>
              <Grid container spacing={2}>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <CalendarTodayIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      تاريخ الطلبية :{" "}
                      {data &&
                        moment(data.dateCreated).format(
                          "DD/MM/yyyy |  HH:mm:ss"
                        )}
                    </Typography>
                  </Box>
                </Grid>

                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <ConfirmationNumberIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      رقم الطلبية : {data ? data.orderID : ""}
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <ShoppingCartIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      كمية المشتريات الكلية - كرتون :{" "}
                      {data ? data.totalQuantityCarton : ""}
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <ShoppingCartIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      كمية المشتريات الكلية - وحدة :{" "}
                      {data ? data.totalQuantitiesUnit : ""}
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <ShoppingCartIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      كمية المشتريات الكلية - قطعة :{" "}
                      {data ? data.totalQuantityPiece : ""}
                    </Typography>
                  </Box>
                </Grid>

                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <LocalAtmIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      ضريبة (17 %) : {data ? data.taxValue : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <ReceiptIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      المجموع قبل الخصومات:{" "}
                      {data ? data.totalBeforeDiscounts : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <DiscountIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      اجمالي الخصومات : {data ? data.amountDeducted : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <PaymentIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      المبلغ المدفوع : {data ? data.theAmountPaid : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <CurrencyExchangeIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      المبلغ للاعادة : {data ? data.amountToReturn : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
                <Grid item xs={12} sm={6}>
                  <Box display="flex" alignItems="center">
                    <AttachMoneyIcon
                      style={{ marginRight: "8px", marginLeft: 10 }}
                    />
                    <Typography variant="body1">
                      المبلغ الكلي للدفع :{" "}
                      {data ? data.totalAmountOfPayment : ""} (شيكل)
                    </Typography>
                  </Box>
                </Grid>
              </Grid>
            </CardContent>
          </Card>

          <ListItem OrderID={searchQuery} />
        </>
      )}
    </Container>
  );
};

export default Find;
