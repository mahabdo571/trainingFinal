import React from 'react';
import { StyleSheet, View, ActivityIndicator, Text } from 'react-native';

const Loading = ({ isLoading, message }) => {
  if (!isLoading) return null;

  return (
    <View style={styles.container}>
    
      <ActivityIndicator size="large" color="#841584" />
      {message && <Text style={styles.message}>{message}</Text>}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.6)', // شبه شفاف للخلفية
    position: 'absolute', // يظهر فوق العناصر الأخرى
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
  },
  message: {
    marginTop: 15,
    fontSize: 16,
    color: 'white',
  },
});

export default Loading;
