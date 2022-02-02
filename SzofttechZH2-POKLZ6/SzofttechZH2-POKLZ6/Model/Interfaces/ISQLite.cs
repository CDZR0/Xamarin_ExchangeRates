using SQLite;

namespace SzofttechZH2_POKLZ6.Model.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string dbName);
    }
}
