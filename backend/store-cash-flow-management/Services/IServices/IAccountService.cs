using Data.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IAccountService
    {
        string loginAccount(AccountLoginModel account);
    }
}
