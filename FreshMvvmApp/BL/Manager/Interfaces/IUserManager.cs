using KantimeEvv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KantimeEvv.BL.Manager.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetUsers();
    }
}