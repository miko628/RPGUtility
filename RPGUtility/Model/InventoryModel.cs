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
        //private  List<Item> Itemlist { get; set; }
        public InventoryModel(Character character)
        {
            //Itemlist = new List<Item>();
            _character = character;
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
                List<Item> Itemlist = await context.Items.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
               // List<Weapon> Weaponlist = await context.Weapons.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
              //  List <Armor> Armorlist = await context.Armors.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Itemlist;
            }
        }
        public async Task<List<Weapon>> GetAllWeapons()
        {
            using (var context = new RpgutilityContext())
            {
              //  List<Item> Itemlist = await context.Items.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                List<Weapon> Weaponlist = await context.Weapons.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
               // List<Armor> Armorlist = await context.Armors.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Weaponlist;
            }
        }
        public async Task<List<Armor>> GetAllArmors()
        {
            using (var context = new RpgutilityContext())
            {
                //List<Item> Itemlist = await context.Items.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
              //  List<Weapon> Weaponlist = await context.Weapons.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                List<Armor> Armorlist = await context.Armors.Where(b => b.CharacterId == _character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Armorlist;
            }
        }
        public async Task DeleteItem(Item item)
        {
            using (var context = new RpgutilityContext())
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteWeapon(Weapon weapon)
        {
            using (var context = new RpgutilityContext())
            {
                context.Weapons.Remove(weapon);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteArmor(Armor armor)
        {
            using (var context = new RpgutilityContext())
            {
                context.Armors.Remove(armor);
                await context.SaveChangesAsync();
            }
        }
      /*  public void AddWeapon(Weapon weapon)
        {
            //Itemlist.Add(item);
        }*/
  /*      public void AddItem(Item item)
        {
            //Itemlist.Add(item);
        }*/
    }
}

