import 'package:flutter/material.dart';

import 'login_screen.dart';
class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return MaterialApp(
      theme: ThemeData.dark(),
      home: Scaffold(
        body: LoginScreen(),
      ),
    );
  }

}