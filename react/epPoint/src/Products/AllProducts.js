import React, { useState, useRef, useEffect } from "react";

import useSWR from "swr";
import axios from "axios";
// import moment from "moment";

import AddBoxIcon from "@mui/icons-material/AddBox";
import AddCircleIcon from "@mui/icons-material/AddCircle";
import { IconButton, Tooltip } from "@mui/material";

import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";

import { API_URL, API_Sales, API_Products, API_Orders } from "../API/API";

import {
  Alert,
  Container,
  Typography,
  TextField,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Paper,
  Box,
  Grid,
  ButtonGroup,
  Button,
} from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import EditProductForm from "./EditProductForm";
import AddPieceToOrder from "../Sales/AddPieceToOrder";

const fetcher = (url) => axios.get(url).then((res) => res.data);

const AllProducts = () => {
  const { data, error, mutate } = useSWR(
    `${API_URL}/${API_Products}`,

    fetcher
  );

  const [selectedDigit, setSelectedDigit] = useState(null);
  const [searchQuery, setSearchQuery] = useState("");
  const [CurrentOrderID, setCurrentOrderID] = useState(null);
  const [CurrentOrders, setCurrentOrders] = useState([]);
  const [TemoData, setTempData] = useState(null);

  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(20);
  const [openEditDialog, setOpenEditDialog] = useState(false);
  const [sortModel, setSortModel] = useState([
    { field: "productID", sort: "desc" },
  ]);
  // إنشاء مرجع لحقل النص
  const textFieldRef = useRef(null);

  // تطبيق التركيز تلقائيًا عند تحميل الصفحة
  useEffect(() => {
    if (textFieldRef.current) {
      textFieldRef.current.focus();
    }
  }, []);

  useEffect(() => {
    // استرجاع البيانات من localStorage عند تحميل الصفحة
    const savedItems =
      JSON.parse(localStorage.getItem("LS_CurrentOrders")) || [];
    setCurrentOrders(savedItems);

    // استرجاع العنصر المختار من sessionStorage عند تحميل الصفحة
    const savedCurrentItem = sessionStorage.getItem("SS_CurrentOrderID");
    if (savedCurrentItem) {
      setCurrentOrderID(savedCurrentItem);
      setSelectedDigit(savedCurrentItem);
      console.log(savedCurrentItem);
    }
  }, []);

  useEffect(() => {
    // حفظ البيانات في localStorage عند تحديث القائمة
    localStorage.setItem("LS_CurrentOrders", JSON.stringify(CurrentOrders));
  }, [CurrentOrders]);

  useEffect(() => {
    // حفظ العنصر المختار في sessionStorage عند تحديثه

    if (CurrentOrderID) {
      sessionStorage.setItem("SS_CurrentOrderID", CurrentOrderID);
    } else {
      sessionStorage.removeItem("SS_CurrentOrderID");
    }
  }, [CurrentOrderID]);

  if (error)
    return (
      <Container sx={{ marginTop: 8 }}>
        <Typography variant="h4" gutterBottom>
          المنتجات
        </Typography>
        <Alert severity="error" sx={{ mt: 4 }}>
          خطأ في جلب البيانات
        </Alert>
      </Container>
    );
  if (!data)
    return (
      <Container sx={{ marginTop: 8 }}>
        <Typography variant="h4" gutterBottom>
          المنتجات
        </Typography>
        <Alert severity="info" sx={{ mt: 4 }}>
          تحميل...
        </Alert>
      </Container>
    );

  const products = data;

  const handleSearchChange = (event) => {
    setSearchQuery(event.target.value);
  };

  const handleCloseAddDialog = async (updatedData) => {
    setOpenEditDialog(false);
    if (updatedData && updatedData.productID > 0) {
      await mutate(); // Re-fetch the data
    }
  };

  const filteredProducts = products.filter(
    (product) =>
      product.productName.toLowerCase().includes(searchQuery.toLowerCase()) ||
      product.barcode.toLowerCase().includes(searchQuery.toLowerCase()) ||
      (product.notes &&
        product.notes.toLowerCase().includes(searchQuery.toLowerCase()))
  );

  const handlePageChange = (params) => {
    setCurrentPage(params.page);
  };

  const columns = [
    // { field: "productID", headerName: "#", width: 70 },
    {
      field: "productName",
      headerName: "اسم المنتج",
      width: 250,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
    // { field: "barcode", headerName: "الباركود", width: 130 },
    // {
    //   field: "lastUpdated",
    //   headerName: "اخر تحديث",
    //   width: 150,
    //   valueFormatter: (params) => moment(params.value).format("DD/MM/yyyy"),
    // },

    // {
    //   field: "quantityInStockCarton",
    //   headerName: "الكمية في المخزن - كرتون",
    //   width: 150,
    // },
    // {
    //   field: "quantityInStockUnit",
    //   headerName: "الكمية في المخزن - وحدة",
    //   width: 150,
    // },
    {
      field: "quantityInStockPiece",
      headerName: "الكمية في المخزن - قطعة",
      width: 150,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
    // { field: "pricePerCarton", headerName: "سعر الكرتونة", width: 130 },
    // { field: "pricePerUnit", headerName: "سعر الوحدة", width: 130 },
    {
      field: "pricePerPiece",
      headerName: "سعر القطعة",
      width: 130,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
    // {
    //   field: "sellingPricePerCarton",
    //   headerName: "سعر بيع الكرتونة",
    //   width: 150,
    // },
    // { field: "sellingPricePerUnit", headerName: "سعر بيع الوحدة", width: 150 },
    {
      field: "sellingPricePerPiece",
      headerName: "سعر بيع القطعة",
      width: 150,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
    // {
    //   field: "sellingPriceTradersPerCarton",
    //   headerName: "سعر البيع المخفض للكرتونة",
    //   width: 150,
    // },
    // {
    //   field: "sellingPriceTradersPerUnit",
    //   headerName: "سعر البيع المخفض للوحدة",
    //   width: 150,
    // },
    {
      field: "sellingPriceTradersPerPiece",
      headerName: "سعر البيع المخفض للقطعة",
      width: 150,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
    // { field: "discountPercentage", headerName: "نسبة التخفيض", width: 130 },
    {
      field: "actions",
      headerName: "اجراءات",
      width: 300,
      renderCell: (params) => (
        <div style={{ display: "flex", justifyContent: "space-around" }}>
          <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            marginLeft={2}
          >
            <Tooltip title="تعديل هذا المنتج">
              <IconButton
                color="secondary"
                onClick={() => handleEdit(params.row)}
              >
                <EditIcon />
              </IconButton>
            </Tooltip>
            <Typography variant="caption">تعديل</Typography>
          </Box>

          <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            marginLeft={2}
          >
            <Tooltip title="حذف هذا المنتج">
              <IconButton
                color="error"
                onClick={() => handleDelete(params.row.productID)}
              >
                <DeleteIcon />
              </IconButton>
            </Tooltip>
            <Typography variant="caption">حذف</Typography>
          </Box>
          <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            marginLeft={2}
          >
            <Tooltip title="اضفة كرتونة للطلبية الحالية">
              <IconButton
                color="secondary"
                disabled={CurrentOrderID ? false : true}
                onClick={() => handleAddCartonToOrder(params.row)}
              >
                <AddBoxIcon />
              </IconButton>
            </Tooltip>
            <Typography variant="caption">اضف كرتونة</Typography>
          </Box>

          <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            marginLeft={2}
          >
            <Tooltip title="اضف وحدة للطلبية الحالية">
              <IconButton
                color="secondary"
                disabled={CurrentOrderID ? false : true}
                onClick={() => handleAddUnitToOrder(params.row)}
              >
                <AddCircleIcon />
              </IconButton>
            </Tooltip>
            <Typography variant="caption">اضف وحدة</Typography>
          </Box>

          <AddPieceToOrder currentOrderId={CurrentOrderID} row={params.row} />
        </div>
      ),
    },
    {
      field: "notes",
      headerName: "ملاحظات",
      width: 200,
      renderCell: (params) => (
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            width: "100%",
          }}
        >
          {params.value}
        </Box>
      ),
    },
  ];

  const handleEdit = (product) => {
    setOpenEditDialog(true);
    setTempData(product);
    if (textFieldRef.current) {
      textFieldRef.current.focus();
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${API_URL}/${API_Products}/${id}`);
      // Re-fetch data or update state here
      if (textFieldRef.current) {
        textFieldRef.current.focus();
      }
      mutate();
    } catch (error) {
      console.error("Error deleting product:", error);
    }
  };

  const handleAddUnitToOrder = async (obj) => {
    if (CurrentOrderID) {
      const response = await axios.post(`${API_URL}/${API_Sales}`, {
        salesID: -1,
        productID: obj.productID,
        orderID: CurrentOrderID,
        amount: 1,
        sellingPrice: obj.sellingPricePerPiece,
        discountPercentage: obj.discountPercentage,
        purchaseType: 2,
        theTotal: -1,
      });
      // setResponAfterAdd(response.data);
    } else {
      alert("الرجاء اختيار طلبية");
    }
  };

  const handleAddCartonToOrder = async (obj) => {
    if (CurrentOrderID) {
      const response = await axios.post(`${API_URL}/${API_Sales}`, {
        salesID: -1,
        productID: obj.productID,
        orderID: CurrentOrderID,
        amount: 1,
        sellingPrice: obj.sellingPricePerPiece,
        discountPercentage: obj.discountPercentage,
        purchaseType: 1,
        theTotal: -1,
      });
      // setResponAfterAdd(response.data);
    } else {
      alert("الرجاء اختيار طلبية");
    }
  };

  const handleClickSelectOrder = (digit) => {
    setSelectedDigit(digit);
    setCurrentOrderID(digit);
  };

  return (
    <Container sx={{ marginTop: 8 }}>
      <Typography variant="h4" gutterBottom>
        المنتجات
      </Typography>

      <Grid container spacing={2} alignItems="center">
        <Grid item>
          <Typography variant="h6" gutterBottom>
            رقم الطلبية الحالية:
          </Typography>
        </Grid>
        <Grid item>
          <ButtonGroup sx={{ marginBottom: "5px" }}>
            {CurrentOrders.map((digit) => (
              <Button
                key={digit}
                variant={
                  selectedDigit + "" === digit + "" ? "contained" : "outlined"
                }
                color={
                  selectedDigit + "" === digit + "" ? "primary" : "secondary"
                }
                sx={{
                  marginRight: "10px",
                  minWidth: "40px",
                  height: "40px",
                  fontSize: "18px",
                }}
                onClick={() => handleClickSelectOrder(digit)}
              >
                {digit}
              </Button>
            ))}
          </ButtonGroup>
        </Grid>
      </Grid>
      <Paper elevation={3} sx={{ padding: 2, marginBottom: 4 }}>
        <TextField
          fullWidth
          inputRef={textFieldRef}
          label="بحث"
          onKeyUp={(e) => {
            if (e.key === "=") {
              //ميزة للمستقبل
            }
            if (e.key === "-") {
              //ميزة للمستقبل
            }

            if (e.key === "Home") {
              //ميزة للمستقبل
            }
          }}
          variant="outlined"
          value={searchQuery}
          onChange={handleSearchChange}
          sx={{ marginBottom: 2 }}
        />
        <Button
          variant="contained"
          color="primary"
          style={{ marginLeft: 10 }}
          onClick={() => {
            setTempData(null);
            setOpenEditDialog(true);
          }}
        >
          اضافة منتج جديد
        </Button>
        <Button
          variant="contained"
          color="primary"
          onClick={async () => {
            const response = await axios.post(`${API_URL}/${API_Orders}`, {});

            setCurrentOrders([...CurrentOrders, response.data]);
            setSelectedDigit(response.data);
            setCurrentOrderID(response.data);

            await mutate();
          }}
        >
          طلبية جديدة
        </Button>

        <Button
          variant="contained"
          color="primary"
          style={{ marginRight: 10 }}
          onClick={() => {
            if (sessionStorage.getItem("SS_CurrentOrderID") == CurrentOrderID) {
              setCurrentOrderID(null);

              sessionStorage.removeItem("SS_CurrentOrderID"); // إزالة العنصر المختار من sessionStorage
            }
            const updatedItems = CurrentOrders.filter(
              (item) => item !== CurrentOrderID
            );
            setCurrentOrders(updatedItems);

            setSelectedDigit(updatedItems[updatedItems.length - 1]);
            setCurrentOrderID(updatedItems[updatedItems.length - 1]);
          }}
        >
          ترحيل الطلبية الحالية
        </Button>
      </Paper>

      <Box
        sx={{
          height: 600,
          width: "100%",

          "& .red-row": {
            backgroundColor: "#ed4040 !important",
            color: "#ffffff",
          },
        }}
      >
        <DataGrid
          rows={filteredProducts}
          getRowId={(row) => row.productID}
          disableSelectionOnClick
          columns={columns}
          pageSize={itemsPerPage}
          onPageChange={handlePageChange}
          pagination
          getRowClassName={(params) => {
            return params.row.quantityInStockPiece < 3 ? "red-row" : "";
          }}
          getRowHeight={() => 65}
          page={currentPage - 1}
          rowsPerPageOptions={[itemsPerPage]}
          sortModel={sortModel}
          onSortModelChange={(model) => setSortModel(model)}
          sx={{
            fontSize: "22px !important",
            "& .MuiDataGrid-row:nth-of-type(odd)": {
              backgroundColor: "#dddecc", // Alternate row color
            },
            "& .MuiDataGrid-row:nth-of-type(even)": {
              backgroundColor: "#9e9e95", // Default row color
            },
          }}
        />
      </Box>

      <Dialog
        open={openEditDialog}
        onClose={() => setOpenEditDialog(false)}
        fullWidth
        maxWidth="md"
      >
        <DialogTitle>
          {TemoData === null ? "اضافة منتج" : "تعديل المنتج"}
        </DialogTitle>
        <DialogContent>
          <EditProductForm
            product={TemoData}
            onCancel={handleCloseAddDialog}
            Mode={TemoData === null ? "ADD" : "Edit"}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenEditDialog(false)} color="secondary">
            إلغاء
          </Button>
        </DialogActions>
      </Dialog>
    </Container>
  );
};

export default AllProducts;
