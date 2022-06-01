using KantimeEvv.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KantimeEvv.Services.Interfaces
{
    public interface IUserService
    {
        [Get("/api/Users")]
        Task<IEnumerable<User>> GetUsers();
    }
}
