using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ipsum_mobile_wallet.Interfaces;
using ipsum_mobile_wallet.Models;
using SQLite;

namespace ipsum_mobile_wallet.Droid
{
    public class SqlLiteDbAccess : ISqlLiteDbAccess
    {
        private string _dbPath => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ipsum.db3");
        private SQLiteAsyncConnection _sqlConnection;

        public SQLiteAsyncConnection Connection
        {
            get
            {
                if (this._sqlConnection == null)
                {
                    this.InitLocalDb();
                }

                return this._sqlConnection;
            }
        }

        public async Task<List<User>> GetRegisteredUserAccountsAsync()
        {
            return await this.Connection.Table<User>().ToListAsync();
        }

        public async Task<int> InsertUserAsync(User user)
        {
            return await this.Connection.InsertAsync(user);
        }

        private void InitLocalDb()
        {
            this._sqlConnection = new SQLiteAsyncConnection(this._dbPath);
            this.Connection.CreateTableAsync<User>();
            this.Connection.InsertAsync(this.MockUser());
        }

        private User MockUser()
        {
            return new User
            {
                Name = "TestAcc",
                Password = "superCoolPassword"
            };
        }
    }
}