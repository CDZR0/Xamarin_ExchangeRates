using System;
using SzofttechZH2_POKLZ6.Model.Data;
using Xamarin.Forms;

namespace SzofttechZH2_POKLZ6.ViewModel.Behaviors
{
    public class RefreshBehavior : Behavior<RefreshView>
    {
        protected override void OnAttachedTo(RefreshView refreshView)
        {
            refreshView.Refreshing += OnRefreshing;
            base.OnAttachedTo(refreshView);
        }

        protected override void OnDetachingFrom(RefreshView refreshView)
        {
            refreshView.Focused -= OnRefreshing;
            base.OnDetachingFrom(refreshView);
        }

        private static async void OnRefreshing(object sender, EventArgs args)
        {
            while (App.CurrencyList == null)
            {
                try
                {
                    App.CurrencyList = await CurrencyQuery.GetListOfCurrenciesAsync();
                }
                catch { }
            }
            ((RefreshView)sender).IsRefreshing = false;
        }
    }
}
