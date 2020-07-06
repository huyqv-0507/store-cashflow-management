using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Data.RequestModel;
using Data.ResponeModel;
using Microsoft.IdentityModel.Tokens;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public bool createAccount(CreateAccountModel account)
        {
            if(account != null)
            {
                var check =_repo.GetAll().SingleOrDefault(x => x.Username == account.Usernanme);
                if (check !=null)
                {
                    var tmp = new Account();
                    tmp.IdRole = account.IdRole;
                    tmp.Username = account.Usernanme;
                    tmp.Password = account.Password;
                    tmp.Name = account.Name;
                    tmp.Status = "active";
                    tmp.TimeCreated = DateTime.Today;

                    _repo.Add(tmp);
                    _unitOfWork.Commit();
                    return true;
                }                       
            }
            return false;
        }

        public bool deleteAccount(long idAccount)
        {
            if(idAccount != null && idAccount > 0)
            {
                var account = _repo.GetById(idAccount);
                if(account != null)
                {
                    _repo.Delete(account);
                    _unitOfWork.Commit();
                    return true;
                }
                
            }
            return false;
        }

        public LoginResponeModel loginAccount(AccountLoginModel account)
        {
            if(account != null)
            {
                var tmp = _repo.GetAll().SingleOrDefault(x => x.Username == account.Username && x.Password == account.Password);
                if(tmp != null)
                {
                    var token = this.generateJwtToken(tmp);
                    LoginResponeModel result = new LoginResponeModel();
                    result.Token = token;
                    result.Name = tmp.Name;
                    result.RoleID = tmp.IdRole;
                    return result;
                }
            }
            return null;
        }

        public bool updateAccount(long idAccount, AccountUpdateModel account)
        {
            if (account != null)
            {
                var tmp = _repo.GetById(idAccount);
                if (tmp != null && tmp.Username.Equals(account.Username)){
                    if (!tmp.Password.Equals(account.Password) && account.Password.Length != 0){
                        tmp.Password = account.Password;
                    }
                    if (tmp.IdRole != account.IdRole && (account.IdRole>1 && account.IdRole <4)) {
                        tmp.IdRole = account.IdRole;
                    }
                   
                    if (!tmp.Name.Equals(account.Name) && account.Name.Length != 0)
                    {
                        tmp.Name = account.Name;
                    }
                    if (tmp.Status.Equals("active") && !account.isActive) {
                        tmp.Status.Equals("lock");
                    }
                    _repo.Update(tmp);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            return false;
        }

        private string generateJwtToken(Account account)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
