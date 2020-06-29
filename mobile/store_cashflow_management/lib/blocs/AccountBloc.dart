import 'package:firebase_auth/firebase_auth.dart';
import 'package:store_cashflow_management/repositories/user_repository.dart';

class AccountBloc {
  AccountRepository accountRepository = AccountRepository();

  Future<FirebaseUser> loginWithGoogle() async {
    return await accountRepository.loginWithGoogle();
  }

  logout() {
    accountRepository.logout();
  }
}
