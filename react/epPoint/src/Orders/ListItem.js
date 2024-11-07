import { DataGrid } from "@mui/x-data-grid";
import React, { useState,useEffect } from "react";
import useSWR from "swr";
import axios from "axios";
import {

  Box
} from "@mui/material";

import { API_URL, API_Sales, API_Products, API_Orders } from "../API/API";

export default function ListItem({OrderID}){
  const fetcher = (url) => axios.get(url).then((res) => res.data);

  const [currentPage, setCurrentPage] = useState(1);
  const [sortModel, setSortModel] = useState([
    { field: "productID", sort: "desc" },
  ]);
  const [itemsPerPage] = useState(20);
  const {data, error, mutate } = useSWR(
    `${API_URL}/${API_Sales}/OrderID/${OrderID}`,
    fetcher
  );

useEffect(()=>{
  mutate()
  console.log(data)
},[])

  const handlePageChange = (params) => {
    setCurrentPage(params.page);
  };
  

  const columns = [
    { field: "salesID", headerName: "#", width: 70 },
     { field: "productName", headerName: "اسم المنتج", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     { field: "sellingPrice", headerName: "السعر", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     
     { field: "discountPercentage", headerName: "خصم ", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     { field: "amount", headerName: "الكمية ", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     { field: "purchaseType", headerName: "النوع ", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     
     { field: "theTotal", headerName: "المجموع ", width: 200
 ,
       renderCell: (params) => (
         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '100%' }}>
           {params.value}
         </Box>
       )
      },
     
     
     ];

    return(<>
    
<Box sx={{ height: 600, width: "100%" }}>
<DataGrid
  rows={data}
  getRowId={(row) => row.salesID}
  disableSelectionOnClick
  columns={columns}
  pageSize={itemsPerPage}
  onPageChange={handlePageChange}
  pagination

  getRowHeight={() => 65}  
  onRowDoubleClick={(e)=>console.log(e.row)}
  page={currentPage - 1}
  rowsPerPageOptions={[itemsPerPage]}
  sortModel={sortModel}
  onSortModelChange={(model) => setSortModel(model)}
  sx={{
    "& .MuiDataGrid-row:nth-of-type(odd)": {
      backgroundColor: "#f5f5f5", // Alternate row color
    },
    "& .MuiDataGrid-row:nth-of-type(even)": {
      backgroundColor: "#fffeee", // Default row color
    },
  }}
/>
</Box>
    </>)
}