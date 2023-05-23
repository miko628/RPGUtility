using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    class ExchangeModel
    {
        private Campaign _campaign;
        public ExchangeModel(Campaign campaign)
        {

            _campaign = campaign;

        }

        public async Task UpdateItem(Character character,Item item)
        {
            using (var context = new RpgutilityContext())
            {
                item.CharacterId = character.CharacterId;
                context.Update(item);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateWeapon(Character character,Weapon item)
        {
            using (var context = new RpgutilityContext())
            {
                item.CharacterId = character.CharacterId;
                context.Update(item);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateArmor(Character character,Armor item)
        {
            using (var context = new RpgutilityContext())
            {
                item.CharacterId = character.CharacterId;
                context.Update(item);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<Character>> GetAll()
        {
            List<Character> characters;
            //  Thread.Sleep(10000);
            //Campaigns.Clear();
            using (var context = new RpgutilityContext())
            {
                characters = await context.Characters.Where(b => b.CampaignId == _campaign.CampaignId).ToListAsync();
                return characters;
            }

        }
        public async Task<List<Item>> GetAllItems(Character character)
        {
            using (var context = new RpgutilityContext())
            {
                List<Item> Itemlist = await context.Items.Where(b => b.CharacterId == character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Itemlist;
            }
        }
        public async Task<List<Weapon>> GetAllWeapons(Character character)
        {
            using (var context = new RpgutilityContext())
            {
                List<Weapon> Weaponlist = await context.Weapons.Where(b => b.CharacterId == character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Weaponlist;
            }
        }
        public async Task<List<Armor>> GetAllArmors(Character character)
        {
            using (var context = new RpgutilityContext())
            {
                List<Armor> Armorlist = await context.Armors.Where(b => b.CharacterId == character.CharacterId).OrderBy(b => b.Name).ToListAsync();
                return Armorlist;
            }
        }
    }
}
