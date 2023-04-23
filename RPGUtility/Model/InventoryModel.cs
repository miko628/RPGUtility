using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class InventoryModel
    {
        private  List<Item> Itemlist { get; set; }
        public InventoryModel()
        {
           Itemlist = new List<Item>();
            
            Itemlist.Add(new Item("Sword", 1, "A sharp sword."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
            Itemlist.Add(new Item("a", 1, "A sturdy shield."));
            Itemlist.Add(new Item("b", 1, "A sturdy shield."));
            Itemlist.Add(new Item("c", 1, "A sturdy shield."));
            Itemlist.Add(new Item("d", 1, "A sturdy shield."));
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));
        }
        public List<Item> getItems()
        {
            return Itemlist;
        }
        public void AddItem(Item item)
        {
            Itemlist.Add(item);
        }
    }
}

