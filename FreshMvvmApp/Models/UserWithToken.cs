using System;
using System.Collections.Generic;
using System.Text;

namespace KantimeEvv.Models
{
    public class UserWithToken : User
    {


        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }


    }
}