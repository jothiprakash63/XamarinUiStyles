using KantimeEvv.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KantimeEvv.Services.Interfaces
{
    public interface ILoginService
    {

        [Post("/api/Users/Login")]
        Task<UserWithToken> LoginAsync(User user);

    }
}
