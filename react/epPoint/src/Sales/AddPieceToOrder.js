import AddIcon from "@mui/icons-material/Add";
import { Typography, Box, IconButton, Tooltip } from "@mui/material";
import axios from "axios";
import React, { useState, useEffect } from "react";
export default function AddPieceToOrder({ currentOrderId, row }) {
  const [currentSelectInDgv, setcurrentSelectInDgv] = useState(null);
  const [ResponAfterAdd, setResponAfterAdd] = useState(null);

  useEffect(() => {
    const updateOrder = async () => {
      if (currentSelectInDgv && row) {
        try {
          const response = await axios.patch(
            `https://localhost:7186/api/Sales/${currentSelectInDgv.salesID}`,
            {
              amount: currentSelectInDgv.amount + 1,
            }
          );
          setResponAfterAdd(response.data);
        } catch (e) {
          console.error("Error updating the amount:", e);
        }
      }
    };

    updateOrder();
  }, [currentSelectInDgv]);

  const getByorderIdAndProdctID = async (orderid, prodctid) => {
    await axios
      .get(
        `https://localhost:7186/api/Sales/OrderId/${orderid}/ProdactId/${prodctid}`
      )
      .then((e) => setcurrentSelectInDgv(e.data))
      .catch((e) => console.log(e.response.status));
  };
  const handleAddPieceToOrder = async (obj) => {
    if (currentOrderId && row) {
      await getByorderIdAndProdctID(currentOrderId, obj.productID);
console.log(currentSelectInDgv)
      if (
        currentSelectInDgv === null &&
        obj.productID !== currentSelectInDgv.productID
      ) {
        const response = await axios.post(`https://localhost:7186/api/Sales`, {
          salesID: "-1",
          productID: obj.productID,
          orderID: currentOrderId,
          amount: 1,
          sellingPrice: obj.sellingPricePerPiece,
          discountPercentage: obj.discountPercentage,
          purchaseType: 3,
          theTotal: -1,
        });

        setResponAfterAdd(response.data);
      }
    } else {
      alert("الرجاء اختيار طلبية");
    }

    // if (textFieldRef.current) {
    //   textFieldRef.current.focus();
    // }
  };

  return (
    <>
      <Box
        display="flex"
        flexDirection="column"
        alignItems="center"
        marginLeft={2}
      >
        <Tooltip title="اضف قطعة للطلبية الحالية ">
          <IconButton
            color="secondary"
            disabled={currentOrderId ? false : true}
            onClick={() => handleAddPieceToOrder(row)}
          >
            <AddIcon />
          </IconButton>
        </Tooltip>
        <Typography variant="caption">اضف قطعة</Typography>
      </Box>
    </>
  );
}
