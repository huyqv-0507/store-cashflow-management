using Data.RequestModel;
using Data.ResponeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IAccountService
    {
        LoginResponeModel loginAccount(AccountLoginModel account);

        bool createAccount(CreateAccountModel account);

        bool deleteAccount(long idAccount);

        bool updateAccount(long idAccount, AccountUpdateModel account);

    }
}
