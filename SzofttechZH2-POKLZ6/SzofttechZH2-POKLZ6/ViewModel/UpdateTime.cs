using System;
using System.ComponentModel;

namespace SzofttechZH2_POKLZ6.ViewModel
{
    class UpdateTime
    {
        public string CurrencyQueryDate { get; set; }

        public UpdateTime()
        {
            CurrencyQueryDate = App.CurrenciesLastUpdated.ToString("yyyy.MM.dd.");
        }
    }
}
