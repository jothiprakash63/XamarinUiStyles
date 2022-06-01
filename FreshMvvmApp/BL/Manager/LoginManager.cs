using KantimeEvv.BL.Manager.Interfaces;
using KantimeEvv.Models;
using KantimeEvv.Services.Interfaces;
using KantimeEvv.Utilities;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KantimeEvv.BL.Manager
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginService _loginService;

        public LoginManager()
        {
            this._loginService = RestService.For<ILoginService>(Constants.BaseUrl);
        }
        public async Task<UserWithToken> Login(string LoginId, string Password)
        {
            try
            {
                User user = new User()
                {
                    //EmailAddress = LoginId,
                    //Password = Password,

                };

                var res = await this._loginService.LoginAsync(user);

                return res;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return null;
                
            }




        }
    }
}
