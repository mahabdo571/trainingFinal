import React, { useState, useRef, useContext, useEffect } from "react";
import {
  Text,
  StyleSheet,
  View,
  TextInput,
  TouchableOpacity,
} from "react-native";
import { FirebaseRecaptchaVerifierModal } from "expo-firebase-recaptcha";

import { app } from "../firebaseConfig";
import { useNavigation } from "@react-navigation/native";

import Loading from "./Loading";
import { AuthContext } from "./AuthContext";

const Login = () => {
  const [phoneNumber, setPhoneNumber] = useState("");
  const [code, setCode] = useState("");
  const [confirm, setConfirm] = useState(null);
  const recaptchaVerifier = useRef(null);
  const [isLoading, setisLoading] = useState(false);
  const { userInfo, login, verifyCode } = useContext(AuthContext);
  const navigation = useNavigation();

  const loginWithPhoneNumber = async () => {
    setisLoading(true);

    const result = await login(phoneNumber, recaptchaVerifier.current);

    setConfirm(result);
    setisLoading(false);
  };

  const confirmCode = async () => {
    setisLoading(true);

    await verifyCode(confirm, code);

    setisLoading(false);
  };

  return (
    <View style={styles.contener}>
      <FirebaseRecaptchaVerifierModal
        ref={recaptchaVerifier}
        firebaseConfig={app.options}
      />
      <Loading isLoading={isLoading} message="Loading data, please wait..." />

      <Text style={styles.title}>ESCAPE HUB</Text>
      {!confirm ? (
        <>
          <Text style={styles.lblPhone}>Enter Phone Number</Text>
          <TextInput
            style={styles.txtPhone}
            placeholder="+970"
            value={phoneNumber}
            keyboardType="phone-pad"
            onChangeText={setPhoneNumber}
          />
          <TouchableOpacity onPress={loginWithPhoneNumber} style={styles.tchop}>
            <Text style={styles.lbltchop}>Send Code</Text>
          </TouchableOpacity>
        </>
      ) : (
        //else
        <>
          <Text style={styles.lblcode}>Enter the code set to your phone</Text>
          <TextInput
            style={styles.txtcode}
            placeholder="Enter Code"
            value={code}
            keyboardType="phone-pad"
            onChangeText={setCode}
          />
          <TouchableOpacity onPress={confirmCode} style={styles.tchopConf}>
            <Text style={styles.lbltchop}>Confirm Code</Text>
          </TouchableOpacity>
        </>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  txtcode: {
    height: 50,
    width: "100%",
    borderColor: "black",
    borderWidth: 1,
    marginBottom: 30,
    padding: 10,
  },
  contener: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    padding: 10,
    backgroundColor: "#bebdbb",
  },
  title: {
    fontSize: 32,
    fontWeigh: "bold",
    marginBottom: 100,
  },
  lblPhone: {
    marginBottom: 20,
    fontSize: 18,
  },
  txtPhone: {
    height: 50,
    width: "100%",
    borderColor: "black",
    borderWidth: 1,
    marginBottom: 30,
    paddingHorizontal: 10,
  },
  tchop: {
    backgroundColor: "#841584",
    padding: 10,
    borderRadius: 5,
    marginBottom: 20,
    alignItems: "center",
  },
  tchopConf: {
    backgroundColor: "#35a32f",
    padding: 10,
    borderRadius: 5,
    marginBottom: 20,
    alignItems: "center",
  },
  lbltchop: {
    color: "white",
    fontSize: 22,
    fontWeight: "bold",
  },
  lblcode: {
    marginBottom: 20,
    fontSize: 18,
  },
});

export default Login;
