import 'package:firebase_core/firebase_core.dart' show FirebaseOptions;
import 'package:flutter/foundation.dart'
    show defaultTargetPlatform, kIsWeb, TargetPlatform;

class DefaultFirebaseOptions {
  static FirebaseOptions get currentPlatform {
    if (kIsWeb) {
      return web;
    }
    switch (defaultTargetPlatform) {
      case TargetPlatform.android:
        return android;
      case TargetPlatform.iOS:
        return ios;
      case TargetPlatform.macOS:
        return macos;
      case TargetPlatform.windows:
        return windows;
      case TargetPlatform.linux:
        throw UnsupportedError(
          'DefaultFirebaseOptions have not been configured for linux - '
          'you can reconfigure this by running the FlutterFire CLI again.',
        );
      default:
        throw UnsupportedError(
          'DefaultFirebaseOptions are not supported for this platform.',
        );
    }
  }

  static const FirebaseOptions web = FirebaseOptions(
    apiKey: 'AIzaSyBjVuXJ_dwTUre1HVqeMF1Eth1WB2xKHuU',
    appId: '1:601254804920:web:c66053e456dbc67028e34d',
    messagingSenderId: '601254804920',
    projectId: 'chatapp-760ee',
    authDomain: 'chatapp-760ee.firebaseapp.com',
    storageBucket: 'chatapp-760ee.firebasestorage.app',
  );

  static const FirebaseOptions android = FirebaseOptions(
    apiKey: 'AIzaSyAsIX7tM8oTduvYxVqcqRqc_-sP7d2Ghg0',
    appId: '1:601254804920:android:497e33e1e69c82f228e34d',
    messagingSenderId: '601254804920',
    projectId: 'chatapp-760ee',
    storageBucket: 'chatapp-760ee.firebasestorage.app',
  );

  static const FirebaseOptions ios = FirebaseOptions(
    apiKey: 'AIzaSyDHc8lxtlMc_J-WyVgolmPwGQHZDasXH2k',
    appId: '1:601254804920:ios:284b18f76420d42928e34d',
    messagingSenderId: '601254804920',
    projectId: 'chatapp-760ee',
    storageBucket: 'chatapp-760ee.firebasestorage.app',
    iosBundleId: 'com.example.chatApp6',
  );

  static const FirebaseOptions macos = FirebaseOptions(
    apiKey: 'AIzaSyDHc8lxtlMc_J-WyVgolmPwGQHZDasXH2k',
    appId: '1:601254804920:ios:284b18f76420d42928e34d',
    messagingSenderId: '601254804920',
    projectId: 'chatapp-760ee',
    storageBucket: 'chatapp-760ee.firebasestorage.app',
    iosBundleId: 'com.example.chatApp6',
  );

  static const FirebaseOptions windows = FirebaseOptions(
    apiKey: 'AIzaSyBjVuXJ_dwTUre1HVqeMF1Eth1WB2xKHuU',
    appId: '1:601254804920:web:211b86493657b21028e34d',
    messagingSenderId: '601254804920',
    projectId: 'chatapp-760ee',
    authDomain: 'chatapp-760ee.firebaseapp.com',
    storageBucket: 'chatapp-760ee.firebasestorage.app',
  );
}
