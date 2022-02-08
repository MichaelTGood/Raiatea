using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raiatea.Databases.Models
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string databaseLocation)
        {
            database = new SQLiteAsyncConnection(databaseLocation);
        }

        public async Task<int> AddToTableAsync<T>(T objToSave) where T : new()
        {
            await database.CreateTableAsync<T>();
            return await database.InsertAsync(objToSave);
        }

        public async Task<List<T>> GetTableAsync<T>() where T: new()
        {
            return await database.Table<T>().ToListAsync();
        }
    }
}
