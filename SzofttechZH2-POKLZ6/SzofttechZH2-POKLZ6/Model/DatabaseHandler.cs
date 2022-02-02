using SQLite;
using SzofttechZH2_POKLZ6.Model.Interfaces;
using Xamarin.Forms;

namespace SzofttechZH2_POKLZ6.Model
{
    public class DatabaseHandler
    {
        private static object locker = new object();
        private SQLiteConnection database;

        public DatabaseHandler()
        {
            database = DependencyService.Get<ISQLite>().GetConnection("lastQueries.db");
            database.CreateTable<DatabaseEntry>();
        }

        public DatabaseEntry GetLastQuery()
        {
            lock (locker)
            {
                if (database.Table<DatabaseEntry>().Count() == 0)
                    return null;
                else
                    return database.Table<DatabaseEntry>().First();
            }
        }
        public void SaveLastQuery(DatabaseEntry DatabaseEntry)
        {
            lock (locker)
            {
                if (GetLastQuery() == null)
                    database.Insert(DatabaseEntry);
            }
        }

        public void DeleteLastQuery()
        {
            lock (locker)
            {
                DatabaseEntry lastQuery = GetLastQuery();
                if (lastQuery != null)
                    database.Delete(lastQuery);
            }
        }
    }
}
