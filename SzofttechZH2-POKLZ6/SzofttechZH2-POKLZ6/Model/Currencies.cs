using System.Collections.Generic;

namespace SzofttechZH2_POKLZ6.Model
{
    public class Currencies
    {
        public Dictionary<string, string> CurrencyName { get; set; }

        public Currencies(Dictionary<string, string> currencies)
        {
            CurrencyName = currencies;
        }

        public override string ToString()
        {
            string buffer = "";
            foreach (KeyValuePair<string, string> item in CurrencyName)
            {
                buffer += item + "\n";
            }
            return buffer;
        }

        public List<string> GetList()
        {
            List<string> currenciesList = new List<string>();
            foreach (string item in CurrencyName.Values)
            {
                currenciesList.Add(item);
            }
            return currenciesList;
        }
    }
}
