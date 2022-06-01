using KanTimeMob.Core.DL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KantimeEvv.Services
{
    public class BaseService : IDisposable
    {
        public SQLiteAsyncConnection DbContext = null;
        public SQLiteAsyncConnection MasterDbContext = null;

        public BaseService()
        {
            this.DbContext = Database.GetConnection(CancellationToken.None);
            this.MasterDbContext = Database.GetMasterDBConnection(CancellationToken.None);
        }

        public void Dispose()
        {

        }
    }
}
