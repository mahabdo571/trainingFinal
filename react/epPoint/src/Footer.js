import React from "react";
import { Box, Typography } from "@mui/material";

const Footer = () => {
  return (
    <Box
      sx={{
        backgroundColor: "#f2ecdc",
        color: "#333",
        padding: 3,
        textAlign: "center",
        position: "static",
        bottom: 0,
        width: "100%",
      }}
    >
      <Typography variant="body1">كل شي و أكثر © 2024</Typography>
    </Box>
  );
};

export default Footer;
