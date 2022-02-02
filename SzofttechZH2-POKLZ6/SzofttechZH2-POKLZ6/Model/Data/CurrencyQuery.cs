//Programhoz felhasznált publikus valuta-árfolyam API
//https://github.com/fawazahmed0/currency-api#readme

using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SzofttechZH2_POKLZ6.Model.Data
{
    public static class CurrencyQuery
    {
        static HttpClient client;

        static CurrencyQuery()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 250000;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Currencies> GetListOfCurrenciesAsync()
        {
            string endpoint = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies.min.json";
            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                System.Console.WriteLine(new Currencies(dict));
                return new Currencies(dict);
            }
            return null;
        }

        public static async Task<SpecificCurrency> GetSpecificCurrencyRatesAsync(string ISOCurrencyCode)
        {
            string endpoint = $"https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/{ISOCurrencyCode}.json";

            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                int firstIndex = json.IndexOf(ISOCurrencyCode);
                json = json.Remove(firstIndex, ISOCurrencyCode.Length).Insert(firstIndex, "Rates");
                json = json.Replace("date", "Date");
                SpecificCurrency specificCurrency = new SpecificCurrency();
                JsonConvert.PopulateObject(json, specificCurrency);
                return specificCurrency;
            }
            return null;
        }

        public static async Task<List<StringWithContent>> GetListAsync(double multiplier, string key)
        {
            SpecificCurrency specificCurrency = await GetSpecificCurrencyRatesAsync(key);

            string[] keys = new string[specificCurrency.Rates.Count];
            int count = 0;
            foreach (KeyValuePair<string, double> item in specificCurrency.Rates)
            {
                keys[count] = item.Key;
                ++count;
            }
            for (int i = 0; i < specificCurrency.Rates.Count; ++i)
            {
                specificCurrency.Rates[keys[i]] *= multiplier;
            }

            if (key != null)
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                dbHandler.DeleteLastQuery();
                dbHandler.SaveLastQuery(new DatabaseEntry { Key = key, Multiplier = multiplier });
            }          

            return specificCurrency.GetFormattedRates(App.CurrencyList, multiplier);
        }
    }
}