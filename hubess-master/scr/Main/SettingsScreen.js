
import React, { useEffect, useState, useContext } from "react";

import { StyleSheet, View, Text, TouchableOpacity } from "react-native";
import { auth, db } from "../../firebaseConfig";
import { getDoc, doc } from "firebase/firestore";
import { useNavigation } from "@react-navigation/native";
import Loading from "../Loading";
import { AuthContext } from "../AuthContext";
const SettingsScreen = () => {
  const navigation = useNavigation();

  const { userInfo, logout, userCloud } = useContext(AuthContext);

  const [isLoading, setisLoading] = useState(false);

  const handelLogout = () => {
    
    try {
      setisLoading(true);
      logout();
      navigation.reset({
        index: 0,
        routes: [{ name: "Login" }],
      });
      setisLoading(false);
    } catch (error) {
      console.error("logOut", error);
    }
  };
  return (
    <View style={styles.contener}>

    
         <Loading isLoading={isLoading} message="Loading data, please wait..." />
    
          <Text style={styles.lbltitle}>welcome to dashbord</Text>
          <Text style={styles.lbltitle}>{userInfo.user.phoneNumber}</Text>
          <TouchableOpacity onPress={handelLogout} style={styles.btnLogout}>
            <Text>Log Out</Text>
          </TouchableOpacity>
          <TouchableOpacity
            onPress={async () => {
              console.log("test btn", userCloud);
            }}
            style={styles.btnLogout}
          >
            <Text>test</Text>
          </TouchableOpacity> 
       
       
        </View>
  )
}

export default SettingsScreen



const styles = StyleSheet.create({
  btnLogout: {
    backgroundColor: "#841584",
    padding: 10,
    borderRadius: 10,
    marginBottom: 20,
    alignItems: "center",
  },
  lbltitle: {
    fontSize: 32,
    fontWeight: "bold",
    marginBottom: 20,
    marginTop: 70,
  },
  contener: {
    flex: 1,
    padding: 0,
    backgroundColor: "#bebbdb",
  },
});