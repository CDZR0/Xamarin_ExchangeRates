using System;
using Xamarin.Forms;
using SzofttechZH2_POKLZ6.Model;
using SzofttechZH2_POKLZ6.Model.Data;
using SzofttechZH2_POKLZ6.Model.Interfaces;
using SQLite;
using System.ComponentModel;
using SzofttechZH2_POKLZ6.ViewModel;

namespace SzofttechZH2_POKLZ6
{
    public partial class App : Application
    {
        public static Currencies CurrencyList { get; set; }
        public static DateTime CurrenciesLastUpdated { get; private set; } = DateTime.Now;
        public static DatabaseEntry SavedCurrency { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            try
            {               
                CurrencyList = await CurrencyQuery.GetListOfCurrenciesAsync();
            }
            catch
            {
                CurrencyList = null;
            }
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
