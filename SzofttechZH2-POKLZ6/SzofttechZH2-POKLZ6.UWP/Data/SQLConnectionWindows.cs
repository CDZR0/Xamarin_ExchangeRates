using SQLite;
using System.IO;
using SzofttechZH2_POKLZ6.Model.Interfaces;
using SzofttechZH2_POKLZ6.UWP.Data;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLConnectionWindows))]
namespace SzofttechZH2_POKLZ6.UWP.Data
{
    class SQLConnectionWindows : ISQLite
    {
        public SQLiteConnection GetConnection(string dbName)
        {
            string folder = ApplicationData.Current.RoamingFolder.Path;
            string path = Path.Combine(folder, dbName);
            System.Console.WriteLine(folder);

            return new SQLiteConnection(path);
        }
    }
}
