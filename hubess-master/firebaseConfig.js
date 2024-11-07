import { initializeApp } from "firebase/app";
import { initializeAuth, getReactNativePersistence  } from "firebase/auth";
import { getFirestore } from "firebase/firestore";

import ReactNativeAsyncStorage from '@react-native-async-storage/async-storage';

const firebaseConfig = {
  apiKey: "AIzaSyB42NhcOQ9BACr0wpDsVwc7hxQbaS2sT1o",
  authDomain: "escapehub-d3866.firebaseapp.com",
  projectId: "escapehub-d3866",
  storageBucket: "escapehub-d3866.appspot.com",
  messagingSenderId: "744615717720",
  appId: "1:744615717720:android:15dbd5f45dac25f508532d",
  measurementId: "",
};
const app = initializeApp(firebaseConfig);

const auth = initializeAuth(app, {
  persistence: getReactNativePersistence(ReactNativeAsyncStorage)
});
const db = getFirestore(app);

export { auth, app ,db};



