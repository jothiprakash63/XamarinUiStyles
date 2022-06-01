using KantimeEvv.Models;
using KantimeEvv.Services.Interfaces;
using KantimeEvv.Utilities;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KantimeEvv.Services
{
    public class LoginService 
    {
        private readonly ILoginService _loginService;

        public LoginService()
        {
            this._loginService = RestService.For<ILoginService>(Constants.BaseUrl);
        }
        public Task<UserWithToken> Login(string LoginId,string Password)
        {
            User user = new User()
            {
                 EmailAddress = LoginId,
                 Password = Password,

            };

           return this._loginService.Login(user);

        }
    }
}
