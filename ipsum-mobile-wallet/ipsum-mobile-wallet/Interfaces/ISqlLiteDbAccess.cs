using ipsum_mobile_wallet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ipsum_mobile_wallet.Interfaces
{
    public interface ISqlLiteDbAccess
    {
        SQLite.SQLiteAsyncConnection Connection { get; }

        Task<List<User>> GetRegisteredUserAccountsAsync();

        Task<int> InsertUserAsync(User user);
    }
}
