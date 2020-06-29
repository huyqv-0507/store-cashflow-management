import 'dart:convert' as convert;

import 'package:google_sign_in/google_sign_in.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:http/http.dart' as http;
import 'package:store_cashflow_management/utils/constranst.dart';
// import 'package:shared_preferences/shared_preferences.dart';

class AccountRepository {
  GoogleSignIn googleSignIn = GoogleSignIn(
    scopes: ['email'],
  );
  FirebaseAuth auth = FirebaseAuth.instance;

  /**
   * Sign Up with google 
   */
  Future<FirebaseUser> loginWithGoogle() async {
    try {
      String key = 'TOKEN_KEY';
      // respone from authenticateLogin
      String data;

      final GoogleSignInAccount googleUser = await googleSignIn.signIn();

      final GoogleSignInAuthentication googleAuth =
          await googleUser.authentication;

      final AuthCredential credential = GoogleAuthProvider.getCredential(
        accessToken: googleAuth.accessToken,
        idToken: googleAuth.idToken,
      );

      final FirebaseUser user =
          (await auth.signInWithCredential(credential)).user;

      user.getIdToken().then((result) {
        return result.token;
      }).then((token) async {
        // data = await authenticateLogin(token);
      });

      // if (data != null) {
      //   SharedPreferences preferences = await SharedPreferences.getInstance();
      //   preferences.setString(key, data);
      // }
      return user;
    } catch (e) {
      print(e.message);
    }
    return null;
  }

  /**
   * @param : idToken
   * Return token and role of the account
   */
  Future<String> authenticateLogin(String idToken) async {
    final authenticateUrl = '$BASE_API/authenticate/account';

    // data send to backend
    Map data = {
      'id': '',
      'username': '',
      'gmail': '',
      'role': '',
      'token': idToken
    };
    var body = convert.jsonEncode(data);

    try {
      final http.Response response = await http.post(
        authenticateUrl,
        headers: {'Content-Type': 'application/json; charset=UTF-8'},
        body: body,
      );
      if (response.statusCode == 200) {
        // return data contains role and token
        return convert.jsonDecode(response.body);
      }
    } catch (e) {
      print(e);
    }
    return null;
  }

  /**
   * Sign out function
   */
  Future<void> logout() async {
    await auth.signOut().then((onValue) {
      googleSignIn.signOut();
    });
  }
}
