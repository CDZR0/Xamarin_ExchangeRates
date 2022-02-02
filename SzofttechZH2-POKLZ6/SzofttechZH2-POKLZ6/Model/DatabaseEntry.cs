using SQLite;

namespace SzofttechZH2_POKLZ6.Model
{
    public class DatabaseEntry
    {
        [PrimaryKey]
        public string Key { get; set; }
        public double Multiplier { get; set; }
    }
}
