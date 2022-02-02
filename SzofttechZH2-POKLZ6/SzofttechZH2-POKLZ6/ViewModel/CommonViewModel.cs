using System.Collections.Generic;
using SzofttechZH2_POKLZ6.Model;
using SzofttechZH2_POKLZ6.Model.Data;

namespace SzofttechZH2_POKLZ6.ViewModel
{
    public class CommonViewModel : NotifyPropertyChangedBase
    {
        private List<StringWithContent> listView;
        public List<StringWithContent> ListView
        {
            get
            {
                return listView;
            }
            set
            {
                listView = value;
                OnPropertyChanged("ListView");
            }
        }

        private double multiplier;
        public double Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
                OnPropertyChanged("Multiplier");
            }
        }

        private string key;
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }

        public CommonViewModel()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            DatabaseEntry entry = dbHandler.GetLastQuery();
            if (entry != null)
            {
                Key = entry.Key;
                Multiplier = entry.Multiplier;
            }
            else
            {
                Multiplier = 1.0;
                ListView = null;
                Key = null;
            }
        }
    }
}
