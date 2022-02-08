using Dapper;
using Dapper.Contrib.Extensions;
using MimeKit;
using Raiatea.Databases.Models;
using Raiatea.EmailLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Raiatea.Databases
{
    public class DatabaseAccess
    {
        private const string databaseFileExtension = ".db";

        private static Dictionary<string, Database> databases = new Dictionary<string, Database>();

        public static Database GetOrCreateDatabase(string databaseName)
        {
            Database database;
            if(databases.TryGetValue(databaseName, out database))
            {
                return database;
            }

            database = new Database(GetDatabaseLocation(databaseName));

            string str = $"Database {databaseName} located at: {GetDatabaseLocation(databaseName)}";

            databases.Add(databaseName, database);
            return database;

        }

        private static string GetDatabaseLocation(string accountId)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), accountId + databaseFileExtension);
        }

    }
}
