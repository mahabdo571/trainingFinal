import React, { useState,useContext } from "react";
import { StyleSheet, View, Text, TouchableOpacity } from "react-native";
import { auth, app, db } from "../firebaseConfig";
import { setDoc, doc } from "firebase/firestore";
import { TextInput } from "react-native-gesture-handler";
import Loading from "./Loading";
import { AuthContext } from "./AuthContext";
const Detail = ({ route, navigation }) => {
     const { uid } = route.params;
  const [name, setName] = useState("");
  const [dob, setDob] = useState("");
  const [gender, setgender] = useState("");
   const [isLoading, setisLoading] = useState(false);
   const {  setuserCloud } = useContext(AuthContext);
  const saveDetail = async () => {
    setisLoading(true)

    try {
      await setDoc(doc(db, "users", uid), {
        name,
        dob,
        gender,
      });
      setuserCloud({  name,
        dob,
        gender})
      navigation.navigate("Dashboard");
    } catch (error) {
      console.error(error);
    }
    setisLoading(false)

  };

  return (
    <View style={styles.contener}>
                  <Loading isLoading={isLoading} message="Loading data, please wait..." />

      <Text style={styles.lblTitleDetail}>Enter Your Detalis</Text>
      <TextInput
        style={styles.txtinput}
        placeholder="Ener Your Name"
        value={name}
        onChangeText={setName}
      />
      <TextInput
        style={styles.txtinput}
        placeholder="Ener Your dob"
        value={dob}
        onChangeText={setDob}
      />
      <TextInput
        style={styles.txtinput}
        placeholder="Ener Your gender"
        value={gender}
        onChangeText={setgender}
      />

      <TouchableOpacity style={styles.btnsave} onPress={saveDetail}>
        <Text style={styles.lblbtn}>Save Detail</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  btnsave: {
    backgroundColor: "#841584",
    padding: 10,
    borderRadius: 5,
    marginBottom: 20,
    alignItems: "center",
  },
  lblbtn: {
    color: "white",
    fontSize: 20,
    fontWeight: "bold",
  },
  txtinput: {
    height: 50,
    width: "100%",
    backgroundColor: "white",
    borderWidth: 1,
    paddingHorizontal: 10,
    marginBottom: 30,
  },
  contener: {
    flex: 1,
    padding: 10,
    backgroundColor: "#bebdbb",
  },
  lblTitleDetail: {
    fontSize: 32,
    fontWeight: "bold",
    marginBottom: 20,
    marginTop: 150,
  },
});

export default Detail;
