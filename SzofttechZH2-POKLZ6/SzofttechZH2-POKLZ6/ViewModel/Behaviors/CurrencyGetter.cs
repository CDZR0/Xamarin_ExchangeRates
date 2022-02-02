using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SzofttechZH2_POKLZ6.Model.Data;
using SzofttechZH2_POKLZ6.Model;

namespace SzofttechZH2_POKLZ6.ViewModel.Behaviors
{
    public class CurrencyGetter : Behavior<Picker>
    {
        public static readonly BindableProperty MultiplierProperty = BindableProperty.Create("Multiplier", typeof(double), typeof(CurrencyGetter), null);
        public static readonly BindableProperty ListViewProperty = BindableProperty.Create("Multiplier", typeof(List<StringWithContent>), typeof(CurrencyGetter), null);
        public static readonly BindableProperty KeyProperty = BindableProperty.Create("Key", typeof(string), typeof(CurrencyGetter), null);

        public double Multiplier
        {
            get { return (double)GetValue(MultiplierProperty); }
            set { SetValue(MultiplierProperty, value); }
        }

        public List<StringWithContent> ListView
        {
            get { return (List<StringWithContent>)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        protected override void OnAttachedTo(Picker picker)
        {
            picker.Focused += OnFocusReceived;
            picker.SelectedIndexChanged += OnSelectedIndexChanged;
            base.OnAttachedTo(picker);
        }

        protected override void OnDetachingFrom(Picker picker)
        {
            picker.Focused -= OnFocusReceived;
            picker.SelectedIndexChanged -= OnSelectedIndexChanged;
            base.OnDetachingFrom(picker);
        }

        private void OnFocusReceived(object sender, FocusEventArgs args)
        {
            if (App.CurrencyList != null)
                ((Picker)sender).ItemsSource = App.CurrencyList.GetList();
            else
            {
                List<string> noInternetList = new List<string>();
                noInternetList.Add("No internet access\nRefresh or restart with Wi-Fi or Mobile Data enabled");
                ((Picker)sender).ItemsSource = noInternetList;
            }
        }

        private async void OnSelectedIndexChanged(object sender, EventArgs args)
        {
            try
            {            
                if (((Picker)sender).SelectedItem != null)
                {
                    string selected = ((Picker)sender).SelectedItem.ToString();
                    if (selected == "No internet access\nRefresh or restart with Wi-Fi or Mobile Data enabled")
                        return;

                    Key = App.CurrencyList.CurrencyName.FirstOrDefault(x => x.Value == selected).Key;

                    if (Multiplier <= 0.0)
                        Multiplier = 1.0;

                    ListView = await CurrencyQuery.GetListAsync(Multiplier, Key);
                }
            }
            catch (Exception) { }
            
        }
    }
}
