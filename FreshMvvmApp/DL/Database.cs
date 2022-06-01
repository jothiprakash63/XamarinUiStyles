
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using System.IO;


namespace KanTimeMob.Core.DL
{
    /// <summary>
    /// A helper class for working with SQLite
    /// </summary>
    public static class Database
    {
#if NETFX_CORE
        private static readonly string Path = KanUtils.GetDbNameByAppType(); 
#elif NCRUNCH
        private static readonly string Path = System.IO.Path.GetTempFileName();
#elif USE_WP8_NATIVE_SQLITE
        private static readonly string Path = System.IO.Path.Combine(System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, KanUtils.GetDbNameByAppType()));
#else
        //private static  string Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),Constants.LocalDatabaseName);
        private static string MasterDBPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "");
#endif
        //private static bool initialized = false;

        public static readonly Type[] TableTypes = new Type[]
        {
            

        };


        public static readonly Type[] MasterTableTypes = new Type[]
      {
           
      };



        /// <summary>
        /// For use within the app on startup, this will create the database
        /// </summary>
        /// <returns></returns>
        //        public static Task Initialize(CancellationToken cancellationToken)
        //        {
        //            Task task = null;

        //            try
        //            {

        //                var connection = new SQLiteAsyncConnection(Path, true);



        //                if (!Settings.Current.IS_DB_EXISTS)
        //                    task = CreateDatabase(new SQLiteConnection(Path, true), cancellationToken);
        //                else
        //                {
        //                    connection.Table<Application>().FirstOrDefaultAsync().ContinueWith(t =>
        //                    {

        //                        try
        //                        {

        //                            if (t.Result == null)
        //                            {
        //                                task = CreateDatabase(new SQLiteConnection(Path, true), cancellationToken);

        //                                if (task != null)
        //                                    task.Wait();
        //                            }
        //                            else
        //                            {

        //                                JDeviceInfo deviceInfo = null;
        //                                INative nat = null;

        //#if __IOS__

        //                                nat = new KanTimeMob.iOSNative.Helper.NativeiOS();
        //#elif __ANDROID__

        //                           //    nat = new KanTimeMob.DroidNative.Helper.NativeDroid();
        //                            nat = new KanTimeMob.MaterialDroid.Helper.NativeDroid();
        //#else
        //                            nat= new KanTimeMob.WinPhone.Helper.NativeWindows(); 
        //#endif

        //                                if (nat != null)
        //                                    deviceInfo = nat.GetDeviceInfo();


        //                                if (t.Result != null && deviceInfo != null && deviceInfo.AppBuildNumber > t.Result.APP_BUILD_NUMBER)
        //                                {
        //                                    task = CreateDatabase(new SQLiteAsyncConnection(Path, true), cancellationToken);

        //                                    if (task != null)
        //                                        task.Wait();

        //                                    t.Result.APP_BUILD_NUMBER = deviceInfo.AppBuildNumber;

        //                                    connection.UpdateAsync(t.Result);


        //                                    //LogService.AddExceptionLogAsync(
        //                                    //    String.Format("~~~~~~~~~ SQLite schema changed sucessfully ~~~~~~~~~ ( BUILD NUMBER= {0},  App Version= {1},  DUID= {2} )",
        //                                    //    deviceInfo.AppBuildNumber, deviceInfo.AppVersion, deviceInfo.DeviceUniqueId));
        //                                }
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            LogService.AddExceptionLogAsync(String.Format("~~~~~~~~~ SQLite schema update failed ~~~~~~~~~"));

        //                            throw ex;
        //                        }
        //                    }).Wait();
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                LogService.AddExceptionLogAsync(ex);
        //            }
        //            return task;
        //        }

        /// <summary>
        /// Global way to grab a connection to the database, make sure to wrap in a using
        /// </summary>
        public static SQLiteAsyncConnection GetConnection(CancellationToken cancellationToken)
        {
            var Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Mydatabase.sqlite");
            return new SQLiteAsyncConnection(Path, true);


        }


        //public static SQLiteConnection GetConnectionByAppType(ApplicationType appType)
        //{
        //     var Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), KanUtils.GetDbNameByAppType(appType));
        //    return new SQLiteConnection(Path, true);
        //}

        public static SQLiteAsyncConnection GetMasterDBConnection(CancellationToken cancellationToken)
        {
                return new SQLiteAsyncConnection(MasterDBPath, true);
        }



        //public static Task InitAppDatabase1(ApplicationType appType)
        //{
        //    try
        //    {
        //        Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), KanUtils.GetDbNameByAppType(appType));

        //        return CreateDatabase(new SQLiteAsyncConnection(Path, true), CancellationToken.None);
        //    } 
        //    catch ( Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //private static Task CreateDatabase1(SQLiteAsyncConnection connection, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return Task.Factory.StartNew(() =>
        //          {
        //        //Create the tables
        //        var createTask = connection.CreateTablesAsync(TableTypes);
        //              createTask.Wait();

        //        //Mark database created
        //        //initialized = true;

        //        //Test ();
        //    });
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public async static Task<bool> InitMasterDatabase()
        {
            // Settings.Current.SetPreviousInstalledAppType();
            //InitMasterAppDatabase();


            //if (Settings.Current.IS_HOSPICE_REGISTERED)
            //{

            //    await InitAppDatabase(ApplicationType.HOSPICE);
            //    AddRegisteredUsersList(ApplicationType.HOSPICE);
            //}

            //if (Settings.Current.IS_HOMEHEALTH_REGISTERED)
            //{
            //    await InitAppDatabase(ApplicationType.HOME_HEALTH);
            //    AddRegisteredUsersList(ApplicationType.HOME_HEALTH);
            //}

            //Settings.Current.IS_HOMEHEALTH_REGISTERED = false;
            //Settings.Current.IS_HOSPICE_REGISTERED = false;

            return true;
        }




        //public static async void AddRegisteredUsersList(ApplicationType appType)
        //{

        //    //try
        //    //{
        //    //    var dbContext = GetConnectionByAppType(appType);
        //    //    var masterdbContext = GetMasterDBConnection(CancellationToken.None);

        //    //    if (dbContext != null)
        //    //    {

        //    //        var user = dbContext.Table<User>().FirstOrDefault();
        //    //        var app = dbContext.Table<Application>().FirstOrDefault();


        //    //        var dbname = Path.GetFileName(dbContext.DatabasePath);

        //    //        if (user != null & app != null)
        //    //        {
        //    //            UserAccount userAccount = new UserAccount()
        //    //            {
        //    //                APP_TYPE = appType,
        //    //                ENVIRONMENT = (EnvironmentType)Settings.Current.ENVIRONMENT_TYPE,
        //    //                HHA = user.HHA,
        //    //                LOGIN_ID = user.LOGIN_ID,
        //    //                REFERENCE_DB = dbname,
        //    //                USER_ID = user.USER_ID,
        //    //                USER_NAME = user.UserFullName,
        //    //                REGISTERED_ON = DateTime.Now
        //    //            };


        //    //            var Issucess = await masterdbContext.InsertAsync(userAccount);

        //    //            if (Issucess == 1)
        //    //            {
        //    //                var list = await masterdbContext.Table<UserAccount>().ToListAsync();

        //    //                int InsertedId = list.Max(X => X.ID);

        //    //                Settings.Current.CURRENT_USER_ACCOUNT_ID = InsertedId;
        //    //                Settings.Current.CURRENT_USER_DATABASE_NAME = userAccount.REFERENCE_DB;
        //    //            }
        //    //        }

        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    throw ex;
        //    //}
        //}


        //public async static  Task<bool> InitDatabase()
        //{

        //    //Settings.Current.SetPreviousInstalledAppType();
        //    //await InitAppDatabase(ApplicationType.HOME_HEALTH);
        //    //return await InitAppDatabase(ApplicationType.HOSPICE);
        //}

        public async static Task<bool> InitUserDatabase()
        {
            var Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Mydatabase.sqlite");

            return await CreateDatabase(new SQLiteConnection(Path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true), CancellationToken.None);

        }

        //public async static  Task<bool> InitAppDatabase(ApplicationType appType)
        //{
        //    try
        //    {


        //         var Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), KanUtils.GetDbNameByAppType(appType));
        //         return await CreateDatabase(new SQLiteConnection(Path,SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true), CancellationToken.None);


        //        //return CreateDatabase(new SQLiteConnection(Path, true), CancellationToken.None);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private static bool InitMasterAppDatabase()
        {
            try
            {


                return CreateMasterDatabase(new SQLiteConnection(MasterDBPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true), CancellationToken.None);


                //return CreateDatabase(new SQLiteConnection(Path, true), CancellationToken.None);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async static Task<bool> CreateDatabase(SQLiteConnection connection, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in TableTypes)
                {
                    connection.CreateTable(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool CreateMasterDatabase(SQLiteConnection connection, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in MasterTableTypes)
                {
                    connection.CreateTable(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        /// <summary>
        /// Checks if Sqlite Database exists or not
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        //private static Task<bool> IsDbExists(SQLiteAsyncConnection connection)
        //{
        //    return connection.QueryAsync<Application>("SELECT * FROM sqlite_master WHERE type = 'table' AND name = 'Application'").ContinueWith(t =>
        //    {
        //        if (t.Result == null || t.Result.Count <= 0)
        //            return false;
        //        else
        //            return true;
        //    });
        //}





        //private static void Test()
        //{
        //    for (int i = 1; i < 11; i++)
        //    {

        //        Users x = new Users()
        //         {
        //             FIRST_NAME = "FirstName" + i.ToString(),
        //             LAST_NAME = "LastName" + (10 + i).ToString(),
        //             DISCIPLINE = "# " + i.ToString() + " Green Square Mkt, Ford Area CA- 089765",
        //             EMAIL_ID = "robert" + (i + 100).ToString() + "@hotmail.com",
        //             PASSWORD = "+91 234 876 " + (i + 1000).ToString(),
        //             LOGIN_ID = "(0543) 387 " + (i + 1000).ToString(),
        //            // USER_TYPE = i/ 2 == 0 ? UserType.Assignment : UserType.PhoneCall,
        //             ROLE = i / 2 == 0 ? UserRole.Clinician : UserRole.Clinician
        //         };

        //        GetConnection(CancellationToken.None).InsertAsync(x);

        //    }
        //}
    }


}

namespace KanTimeMob.Core
{
    public static class DbExtensions
    {
        /// <summary>
        /// Async Extension to check if Table exist or no
        /// </summary>
        /// <param name="conection"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsTableExistingAsync(this SQLiteAsyncConnection conection, Type c)
        {
            return conection.ExecuteScalarAsync<Int32>(String.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}'", c.Name)).ContinueWith(t =>
            {
                return t.Result > 0;
            }).Result;
        }

        /// <summary>
        /// Extension to check if Table exist or no
        /// </summary>
        /// <param name="conconection"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsTableExisting(this SQLiteConnection conconection, Type c)
        {
            return conconection.ExecuteScalar<Int32>(String.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}'", c.Name)) > 0;
        }

        /// <summary>
        /// Async Extension to clear table data if it exists
        /// </summary>
        /// <param name="conection"></param>
        /// <param name="tableType"></param>
        public static void ClearTableDataAsync(this SQLiteAsyncConnection conection, Type tableType)
        {
            if (conection.IsTableExistingAsync(tableType))
                conection.ExecuteAsync(String.Format(@"Delete from {0}", tableType.Name)).Wait();
        }

        /// <summary>
        /// Extension to clear table data if it exists
        /// </summary>
        /// <param name="conection"></param>
        /// <param name="tableType"></param>
        public static void ClearTableData(this SQLiteConnection conection, Type tableType)
        {
            if (conection.IsTableExisting(tableType))
                conection.Execute(String.Format(@"Delete from {0}", tableType.Name));
        }
    }
}