using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SzofttechZH2_POKLZ6.Model
{
    public class SpecificCurrency
    {
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }

        public override string ToString()
        {
            string buffer = "";
            foreach (KeyValuePair<string, double> item in Rates)
            {
                buffer += item + "\n";
            }
            return buffer;
        }

        public DateTime? GetDateAsDateTime()
        {
            string pattern = "yyyy-MM-dd";
            if (DateTime.TryParseExact(Date, pattern, null, DateTimeStyles.None, out DateTime parsedDate))
                return parsedDate;
            else 
                return null;
        }

        public List<StringWithContent> GetFormattedRates(Currencies currencyList, double multiplier)
        {
            List<StringWithContent> formatted = new List<StringWithContent>();
        
            foreach (var item in Rates)
            {
                string name = currencyList.CurrencyName.FirstOrDefault(x => x.Key == item.Key).Value;
                StringWithContent strCt = new StringWithContent(name, item.Value.ToString());
                formatted.Add(strCt);
            }
        
            return formatted;
        }
    }
}
