using AppTempoAgoraSqlite.Helpers;
using AppTempoAgoraSqlite.Helpers.MauiAppTempoSQLite.Helpers;
using AppTempoAgoraSqlite.Models;
using SQLite;

namespace AppTempoAgoraSqlite.Helpers
{
    public class SQLiteDatabaseHelperBase1
    {

        public Task<List<Tempo>> GetAll() => _conn.Table<Tempo>().ToListAsync();

        public Task<int> Insert(Tempo p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Tempo>> Search(string q)
            {
                string sql = "SELECT * FROM Tempo " +
                             "WHERE description LIKE '%" + q + "%'";

                return _conn.QueryAsync<Tempo>(sql);
            }
    }
}