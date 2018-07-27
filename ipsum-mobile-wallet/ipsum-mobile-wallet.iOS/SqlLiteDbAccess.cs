using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using ipsum_mobile_wallet.Interfaces;
using ipsum_mobile_wallet.Models;
using SQLite;
using UIKit;

namespace ipsum_mobile_wallet.iOS
{
    public class SqlLiteDbAccess : ISqlLiteDbAccess
    {
        private string _dbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "ipsum.db3");
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
        }
    }
}