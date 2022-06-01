using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KantimeEvv.BL.Manager.Interfaces
{
    public interface ILoginManager
    {
        Task<UserWithToken> Login(string LoginId, string Password);

    }
}
