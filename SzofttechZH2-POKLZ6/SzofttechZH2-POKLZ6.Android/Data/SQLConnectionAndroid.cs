using SQLite;
using System.IO;
using SzofttechZH2_POKLZ6.Droid.Data;
using SzofttechZH2_POKLZ6.Model.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLConnectionAndroid))]
namespace SzofttechZH2_POKLZ6.Droid.Data
{
    class SQLConnectionAndroid : ISQLite
    {
        public SQLiteConnection GetConnection(string dbName)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, dbName);

            return new SQLiteConnection(path);
        }
    }
}