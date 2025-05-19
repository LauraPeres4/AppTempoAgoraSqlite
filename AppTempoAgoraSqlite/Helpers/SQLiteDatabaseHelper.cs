using SQLite;
using AppTempoAgoraSqlite.Helpers.MauiAppTempoSQLite.Helpers;



namespace AppTempoAgoraSqlite.Helpers
{
    public class SQLiteDatabaseHelper : SQLiteDatabaseHelperBase1
    {
            readonly SQLiteAsyncConnection _conn;

            public SQLiteDatabaseHelper(string path)
            {
                _conn = new SQLiteAsyncConnection(path);
                _conn.CreateTableAsync<MauiAppTempoSQLite.Helpers.Tempo>().Wait();
            }

        public Task<int> Delete(int id)
            {
                return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
            }
    } // Fecha classe SQLiteDatabaseHelper
}


