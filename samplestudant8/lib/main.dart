import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: LoginScreen(),
      ),
    );
  }
}

class LoginScreen extends StatefulWidget {
  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  bool _isLoading = false;

  Future<void> login(String email, String password) async {
    setState(() {
      _isLoading = true;
    });

    final url = Uri.parse('http://192.168.1.24:5171/api/Auth/login'); // ضع رابط API الخاص بتسجيل الدخول.
    final response = await http.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode({'email': email, 'password': password}),
    );

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      final token = data['token']; // تأكد من أن هذا هو اسم الحقل في الاستجابة.
      print(data);
      // حفظ التوكن في Shared Preferences
      final prefs = await SharedPreferences.getInstance();
      await prefs.setString('authToken', token);

      print('Login successful, Bearer token saved: $token');

      // الانتقال إلى الصفحة الرئيسية
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => HomePage()),
      );
    } else {
      print('Login failed: ${response.body}');
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Login failed! Please check your credentials.')),
      );
    }

    setState(() {
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Login')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextField(
              controller: _emailController,
              decoration: InputDecoration(labelText: 'Email'),
            ),
            TextField(
              controller: _passwordController,
              decoration: InputDecoration(labelText: 'Password'),
              obscureText: true,
            ),
            SizedBox(height: 20),
            _isLoading
                ? CircularProgressIndicator()
                : ElevatedButton(
                    onPressed: () => login(
                      _emailController.text,
                      _passwordController.text,
                    ),
                    child: Text('Login'),
                  ),
          ],
        ),
      ),
    );
  }
}

class HomePage extends StatelessWidget {
  Future<String?> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString('authToken');
  }

  Future<void> fetchProtectedData() async {
    final token = await getToken();
    final url =
        Uri.parse('http://192.168.1.24:5171/api/Student/All'); // رابط API محمية.

    final response = await http.get(
      url,
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $token', // إضافة Bearer Token.
      },
    );

    if (response.statusCode == 200) {
      print('Protected data: ${response.body}');
    } else {
      print('Failed to fetch protected data: ${response.statusCode}');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Home Page')),
      body: Center(
        child: ElevatedButton(
          onPressed: fetchProtectedData,
          child: Text('Fetch Protected Data'),
        ),
      ),
    );
  }
}
