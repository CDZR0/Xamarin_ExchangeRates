namespace SzofttechZH2_POKLZ6.Model
{
    public class StringWithContent
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public StringWithContent(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name + Value;
        }
    }
}
