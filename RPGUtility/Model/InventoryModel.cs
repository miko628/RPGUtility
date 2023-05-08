using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
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
        private Character _character;
        private  List<Item> Itemlist { get; set; }
        public InventoryModel()
        {
           Itemlist = new List<Item>();
            
            /*Itemlist.Add(new Item("Sword", 1, "A sharp sword."));
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
            Itemlist.Add(new Item("e", 1, "A sturdy shield."));*/
        }

        public async Task <List<Item>> GetAllItems()
        {
            using (var context = new RpgutilityContext())
            {
                Itemlist = await context.Items.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Itemlist;
            }
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

