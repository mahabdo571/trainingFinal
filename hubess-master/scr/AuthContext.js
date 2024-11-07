import React, { createContext, useState, useRef, useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { auth, db } from "../firebaseConfig";
import { signInWithPhoneNumber } from "@firebase/auth";
import { getDoc, doc } from "firebase/firestore";
import { useNavigation } from "@react-navigation/native";
export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [userInfo, setUser] = useState(null);
  const [userCloud, setuserCloud] = useState(null);
  const navigation = useNavigation();
  useEffect(() => {
    const checkUser = async () => {
      const storedUser = await AsyncStorage.getItem("user");

      if (storedUser) {
        setUser(JSON.parse(storedUser));
        navigation.navigate("Dashboard");
      } else {
        setUser(null);
        navigation.reset({
          index: 0,
          routes: [{ name: "Login" }],
        });
      }
    };
    checkUser();
  }, []);

  const login = async (phoneNumber, recaptchaVerifier) => {
    try {
      return await signInWithPhoneNumber(auth, phoneNumber, recaptchaVerifier);
    } catch (error) {
      console.error("Login failed ", error);
    }
  };
  const verifyCode = async (confirmation, code) => {
    await confirmation
      .confirm(code)
      .then(async (result) => {
        setUser(result);
        AsyncStorage.setItem("user", JSON.stringify(result));
        const docRef = doc(db, "users", result.user.uid);
        const docSnap = await getDoc(docRef);

        console.log("userCloud", userCloud);

        if (docSnap.exists()) {
          setuserCloud(docSnap.data());
          navigation.navigate("Dashboard");
        } else {
          navigation.navigate("Detail", { uid: result.user.uid });
        }
      })
      .catch((error) => {
        console.error("fffff", error);
      });
  };
  const logout = async () => {
    try {
      await auth.signOut();
      await AsyncStorage.removeItem("user");
    } catch (error) {
      console.error("Logout failed", error);
    }
  };

  return (
    <AuthContext.Provider
      value={{
        userInfo,
        login,
        verifyCode,
        logout,

        userCloud,
        setuserCloud,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
