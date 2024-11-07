import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter as Router } from "react-router-dom";
import App from "./App";
import CssBaseline from "@mui/material/CssBaseline";
import { ThemeProvider, createTheme } from "@mui/material/styles";

// const theme = createTheme({
//   palette: {
//     primary: {
//       main: "#000000",
//     },
//     background: {
//       default: "#ffffff",
//     },
//   },
//   typography: {
//     fontFamily: "Arial, sans-serif",
//   },
// });
// إنشاء الثيم وتخصيص الألوان
const theme = createTheme({
  palette: {
    primary: {
      main: '#00796B', // اللون الأساسي الذي تفضله
      contrastText: '#fff', // لون النص الذي يتناقض مع اللون الأساسي
    },
    secondary: {
      main: '#FF5722', // اللون الثانوي
      contrastText: '#fff', // لون النص الذي يتناقض مع اللون الثانوي
    },
    background: {
      default: '#f5f5f5', // لون خلفية التطبيق الافتراضي
      paper: '#fff', // لون خلفية الأوراق (مثل البطاقات)
    },
    text: {
      primary: '#333', // لون النص الأساسي
      secondary: '#666', // لون النص الثانوي
    },
    divider: '#e0e0e0', // لون الفاصل بين العناصر
  },
  typography: {
    // تخصيص أنماط النصوص الافتراضية
    fontFamily: 'Roboto, Arial, sans-serif',
    h4: {
      fontWeight: 600,
    },
    h6: {
      fontWeight: 400,
    },
  },
});
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  // <React.StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <App />
      </Router>
    </ThemeProvider>
  // </React.StrictMode>
);
