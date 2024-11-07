import React from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import { Button, Box, Container, Badge, IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import StorefrontIcon from "@mui/icons-material/Storefront";
import SettingsIcon from "@mui/icons-material/Settings";
import BorderColorOutlinedIcon from '@mui/icons-material/BorderColorOutlined';
import SearchIcon from '@mui/icons-material/Search';
const Header = ({ cartItemsCount }) => {
  return (
    <AppBar position="fixed" sx={{ backgroundColor: "#f2ecdc", color: "#333" }}>
      <Container>
        <Toolbar disableGutters>
          <Typography variant="h6" sx={{ flexGrow: 1 }}>
          كل شي و أكثر
          </Typography>
          <Box sx={{ display: "flex", alignItems: "center", ml: "auto" }}>
            <IconButton color="inherit" component={Link} to="/orders">
              <SearchIcon sx={{margin:1}} />
              البحث عن طلبية
            </IconButton>

            <IconButton color="inherit" component={Link} to="/">
              <StorefrontIcon sx={{margin:1}} />
              المتجر
            </IconButton>

            <IconButton color="inherit" component={Link} to="/Products">
              <StorefrontIcon sx={{margin:1}} />
              المنتجات
            </IconButton>
       
            <IconButton color="inherit" component={Link} to="/setting">
              <SettingsIcon sx={{margin:1}} />
              الاعدادات
            </IconButton>

            {/* <Button color="inherit" component={Link} to="/cart">
              <Badge badgeContent={cartItemsCount} color="error">
              
                <ShoppingCartIcon sx={{margin:.6}}/>
                
              </Badge>
           3
            </Button> */}
            <Button color="inherit" component={Link} to="/cart">
  <Badge
    badgeContent={
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
       
        <span style={{ fontSize: '0.7em', marginTop: '2px' }}>{333} $</span>
      </div>
    }
    color="error"
  >
    
    <ShoppingCartIcon sx={{ margin: 0.6 }} />
  </Badge>
</Button>

          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default Header;
