using System;
using System.Collections.Generic;
using System.Text;
using SzofttechZH2_POKLZ6.Model.Data;
using SzofttechZH2_POKLZ6.Model;

namespace SzofttechZH2_POKLZ6.ViewModel
{
    public class CurrencyList
    {
        public List<string> AllCurrencies { get; private set; }

        public CurrencyList()
        {
            if (App.CurrencyList != null)
                AllCurrencies = App.CurrencyList.GetList();
        }
    }
}
