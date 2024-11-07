import "react-native-gesture-handler";
import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import Login from "./scr/Login";
import Detail from "./scr/Detail";
import Dashboard from "./scr/Dashboard";
import { AuthProvider } from "./scr/AuthContext";

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
    <AuthProvider>

        <Stack.Navigator initialRouteName="Login">
          <Stack.Screen
            name="Login"
            component={Login}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Detail"
            component={Detail}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Dashboard"
            component={Dashboard}
            options={{ headerShown: false }}
          />
        </Stack.Navigator>
      
    </AuthProvider>
    </NavigationContainer>
  );
}
