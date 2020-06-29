import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:store_cashflow_management/blocs/AccountBloc.dart';

class LoginScreen extends StatelessWidget {
  AccountBloc bloc = AccountBloc();

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size.width;
    return Scaffold(
      backgroundColor: Colors.white,
      body: SingleChildScrollView(
        child: Container(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              Container(
                height: 400,
                width: size,
                decoration: BoxDecoration(
                    image: DecorationImage(
                        image: AssetImage('assets/images/background1.jpg'),
                        fit: BoxFit.cover)),
                child: Container(
                  margin: EdgeInsets.symmetric(
                      horizontal: size * .25, vertical: size * .1),
                  child: Text(
                    "Login Page",
                    style: TextStyle(
                        color: Colors.white,
                        fontSize: 40,
                        fontWeight: FontWeight.bold),
                  ),
                ),
              ),
              loginForm()
            ],
          ),
        ),
      ),
    );
  }

  Padding loginForm() {
    return Padding(
      padding: EdgeInsets.all(30),
      child: Column(
        children: <Widget>[
          Container(
            padding: EdgeInsets.all(5),
            decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(10),
                boxShadow: [
                  BoxShadow(
                      color: Color.fromRGBO(143, 148, 251, 2),
                      blurRadius: 20,
                      offset: Offset(0, 10))
                ]),
            child: Column(
              children: <Widget>[
                Container(
                  padding: EdgeInsets.all(8),
                  decoration: BoxDecoration(
                      border:
                          Border(bottom: BorderSide(color: Colors.grey[300]))),
                  child: TextField(
                    decoration: InputDecoration(
                        icon: Icon(Icons.people),
                        border: InputBorder.none,
                        hintText: "Email or username",
                        hintStyle: TextStyle(
                            color: Colors.grey[400],
                            fontWeight: FontWeight.bold)),
                  ),
                ),
                Container(
                  padding: EdgeInsets.all(8),
                  decoration: BoxDecoration(
                      border:
                          Border(bottom: BorderSide(color: Colors.grey[100]))),
                  child: TextField(
                    decoration: InputDecoration(
                        icon: Icon(Icons.lock),
                        border: InputBorder.none,
                        hintText: "Password",
                        hintStyle: TextStyle(
                            color: Colors.grey[400],
                            fontWeight: FontWeight.bold)),
                  ),
                )
              ],
            ),
          ),
          SizedBox(height: 30),
          loginButton(),
          SizedBox(height: 10),
          loginWithGoogleButton()
        ],
      ),
    );
  }

  Container loginWithGoogleButton() {
    return Container(
      height: 50,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          gradient: LinearGradient(
              stops: [0.3, 1, 1],
              colors: [Colors.green, Colors.yellow[100], Colors.yellow[300]])),
      child: SizedBox.expand(
          child: FlatButton(
        onPressed: () async {
          FirebaseUser user = await bloc.loginWithGoogle();
          print(user.email);
        },
        child: Text(
          "Google",
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 25),
        ),
      )),
    );
  }

  Container loginButton() {
    return Container(
      height: 50,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          gradient: LinearGradient(
              stops: [0.3, 1, 1],
              colors: [Colors.green, Colors.yellow[100], Colors.yellow[300]])),
      child: SizedBox.expand(
          child: FlatButton(
        onPressed: () {
          bloc.logout();
        },
        child: Text(
          "Login",
          style: TextStyle(
              color: Colors.white, fontWeight: FontWeight.bold, fontSize: 25),
        ),
      )),
    );
  }
}
