using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class ItemModel
    {
        public ObservableCollection<string> ItemType { get; set; }
        public ItemModel()
        {
            ItemType = new ObservableCollection<String> { "Przedmiot", "Broń", "Pancerz" };
        }
    }
    }

