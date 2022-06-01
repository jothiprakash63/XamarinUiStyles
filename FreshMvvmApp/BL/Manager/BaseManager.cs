using KantimeEvv.Services.Interfaces;
using KantimeEvv.Utilities;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace KantimeEvv.BL.Manager
{
    public class BaseManager
    {
        private readonly ILoginService _loginService;
        public BaseManager()
        {
            this._loginService = RestService.For<ILoginService>(Constants.BaseUrl);
        }
    }
}
