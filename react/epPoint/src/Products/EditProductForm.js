import React, { useState } from "react";
import { TextField, Button, Box } from "@mui/material";
import UpdateDataComponent from "../UpdateDataComponent";
import AddDataCompo from "./AddDataCompo";

const EditProductForm = ({ product, onCancel, Mode }) => {
  const [productData, setProductData] = useState(
    Mode === "ADD" && product === null ? {} : product
  );

  const [update, setUpdate] = useState(false);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setProductData({ ...productData, [name]: value });
  };

  const handleSave = () => {
    setUpdate(true);
  };

  const handleUpdateSuccess = (updatedData) => {
    setUpdate(false);
    Mode = "ُEdit";
    setProductData(updatedData);

    // يمكنك تحديث الحالة العليا أو تنفيذ أي شيء آخر بعد التحديث بنجاح.
    onCancel(updatedData); // إغلاق النموذج بعد التحديث بنجاح
  };

  const handleUpdateError = (error) => {
    setUpdate(false);
    console.error("Update error:", error);
    // التعامل مع الخطأ حسب الحاجة
  };

  return (
    <Box sx={{ padding: 2, boxShadow: 3, borderRadius: 2 }}>
      <TextField
        label="اسم المنتج"
        name="productName"
        value={productData.productName}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="الباركود"
        name="barcode"
        value={productData.barcode}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="الكمية في المخزن - كرتون"
        name="quantityInStockCarton"
        value={productData.quantityInStockCarton}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="الكمية في المخزن - وحدة"
        name="quantityInStockUnit"
        value={productData.quantityInStockUnit}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="الكمية في المخزن - قطعة"
        name="quantityInStockPiece"
        value={productData.quantityInStockPiece}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر الكرتونة"
        name="pricePerCarton"
        value={productData.pricePerCarton}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر الوحدة"
        name="pricePerUnit"
        value={productData.pricePerUnit}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر القطعة"
        name="pricePerPiece"
        value={productData.pricePerPiece}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع الكرتونة"
        name="sellingPricePerCarton"
        value={productData.sellingPricePerCarton}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع الوحدة"
        name="sellingPricePerUnit"
        value={productData.sellingPricePerUnit}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع القطعة"
        name="sellingPricePerPiece"
        value={productData.sellingPricePerPiece}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع الكرتونة المخفض"
        name="sellingPriceTradersPerCarton"
        value={productData.sellingPriceTradersPerCarton}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع الوحدة المخفض"
        name="sellingPriceTradersPerUnit"
        value={productData.sellingPriceTradersPerUnit}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="سعر بيع القطعة المخفض"
        name="sellingPriceTradersPerPiece"
        value={productData.sellingPriceTradersPerPiece}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="نسبة الخصم"
        name="discountPercentage"
        value={productData.discountPercentage}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label="القسم"
        name="categoryId"
        value={productData.categoryId}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />

      <TextField
        label="ملاحظات"
        name="notes"
        value={productData.notes}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />

      <Button
        variant="contained"
        color="primary"
        onClick={handleSave}
        sx={{ mt: 2 }}
      >
        حفظ
      </Button>
      {update && Mode === "Edit" && (
        <UpdateDataComponent
          productData={productData}
          onSuccess={handleUpdateSuccess}
          onError={handleUpdateError}
        />
      )}

      {update && Mode === "ADD" && (
        <AddDataCompo
          productData={productData}
          onSuccess={handleUpdateSuccess}
          onError={handleUpdateError}
        />
      )}
    </Box>
  );
};

export default EditProductForm;
