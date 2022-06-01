
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
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager()
        {
            this._userService = RestService.For<IUserService>(Constants.BaseUrl);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {

                var res = await this._userService.GetUsers();

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
