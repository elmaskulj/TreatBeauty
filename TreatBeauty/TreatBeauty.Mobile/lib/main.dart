import 'package:flutter/material.dart';
import 'package:treatbeauty/pages/Home.dart';
import 'package:treatbeauty/pages/Login.dart';
import 'package:treatbeauty/pages/Search.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Login(),
      routes: {
        '/home' : (context)=>Home(),
        '/search' : (context)=>Search(),
      },
    );
  }
}