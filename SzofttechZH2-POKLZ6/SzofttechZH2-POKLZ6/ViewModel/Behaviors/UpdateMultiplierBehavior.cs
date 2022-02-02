using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using SzofttechZH2_POKLZ6.Model;
using SzofttechZH2_POKLZ6.Model.Data;
using Xamarin.Forms;

namespace SzofttechZH2_POKLZ6.ViewModel.Behaviors
{
    public class UpdateMultiplierBehavior : Behavior<Entry>
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

        public string ListViewName { get; set; }

        protected override void OnAttachedTo(Entry entry)
        {
            Multiplier = 1.0;
            entry.Completed += OnCompletedAsync;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Completed -= OnCompletedAsync;
            base.OnDetachingFrom(entry);
        }

        private async void OnCompletedAsync(object sender, EventArgs args)
        {
            string text = ((Entry)sender).Text.Replace(',', '.');
            Multiplier = double.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
            if (Multiplier <= 0.0)
                Multiplier = 1.0;

            ListView = await CurrencyQuery.GetListAsync(Multiplier, Key);
        }
    }
}
