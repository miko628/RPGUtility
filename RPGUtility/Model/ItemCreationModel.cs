using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    class ItemCreationModel
    {
        public ObservableCollection<string> ItemType { get; set; }
        public ItemCreationModel()
        {
            ItemType = new ObservableCollection<String> { "Przedmiot", "Broń", "Pancerz" };
        }
    }
}
