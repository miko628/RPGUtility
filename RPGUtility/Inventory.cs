using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using RPGUtility.Models;

namespace RPGUtility.Model
{
    class EquipmentModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public EquipmentModel()
        {
            
        }
        public void AddItem(Item item)
        {

        }
    }
}
