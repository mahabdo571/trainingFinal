import React, { useEffect, useState, useContext } from "react";
import { StyleSheet, View, Text, TouchableOpacity } from "react-native";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const Tab = createBottomTabNavigator();
import HomeScreen from "./HomeScreen";
import SettingsScreen from "./SettingsScreen";
import MapScreen from "./MapScreen";
import Icon from 'react-native-vector-icons/Ionicons';


export default function MainAfterLogin(){



return(

 <Tab.Navigator>
      <Tab.Screen 
      name="Home" 
      component={HomeScreen} 
      options={{  
          tabBarIcon: ({ color, size }) => (
            <Icon name="home-outline" color={color} size={size} />
          )
        }} />
      <Tab.Screen name="Map" component={MapScreen}  options={{  
          tabBarIcon: ({ color, size }) => (
            <Icon name="map-outline" color={color} size={size} />
          )
        }} />
      <Tab.Screen name="Settings" component={SettingsScreen}  options={{  
          tabBarIcon: ({ color, size }) => (
            <Icon name="settings-outline" color={color} size={size} />
          )
        }} />
    </Tab.Navigator>

  
)

}


const styles = StyleSheet.create({



})