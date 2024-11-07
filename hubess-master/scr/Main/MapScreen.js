import React from "react";
import { StyleSheet, View, Text, TouchableOpacity } from "react-native";
import MapView, { Marker } from "react-native-maps";
const MapScreen = () => {
  return (
    <View style={styles.container}>
      <MapView
        initialRegion={{
          latitude: 32.178523,
          longitude: 34.971925,
          latitudeDelta: 0.0922,
          longitudeDelta: 0.0421,
        }}
        style={styles.map}
      >
        <Marker
          key={0}
          coordinate={{ latitude: 32.178523, longitude: 34.971925 }}
          title={"test mark 1"}
          description={"test descrption mark 1"}
          style={styles.Mark}
        />

        <Marker
          key={1}
          coordinate={{ latitude: 32.278523, longitude: 34.981925 }}
          title={"test mark 2"}
          description={"test descrption mark 2"}
          style={styles.Mark}
        />
      </MapView>
    </View>
  );
};

export default MapScreen;
const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  map: {
    width: "100%",
    height: "100%",
  },
  Mark: {
    backgroundColor: "#00ff00",
  },
});
