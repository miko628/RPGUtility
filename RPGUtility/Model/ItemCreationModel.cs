using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.Model
{
    class ItemCreationModel
    {
        private Character _character;
        public ObservableCollection<string> ItemType { get; set; }
        public ItemCreationModel(Character character)
        {
            _character = character;
            ItemType = new ObservableCollection<String> { "Przedmiot", "Broń", "Pancerz" };
        }

        public async Task AddItem(BitmapImage bitimage,string name,int quantity,string description)
        {
            byte[] image=ImageEncoder.BitmapImagetobytearray(bitimage);
            using (var context = new RpgutilityContext())
            {
                var item = context.Set<Item>();
                Item pom = new Item { ItemImage=image, Name=name,Quantity=quantity,Description=description,CharacterId=_character.CharacterId };
                //Act pom = new Act { Name = $"Akt {Acts.Count()}", Description = "Testowe", CampaignId = _campaign.CampaignId };
                await item.AddAsync(pom);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddWeapon(BitmapImage bitimage, string name,string type, int quantity, string description,double damage)
        {
            byte[] image = ImageEncoder.BitmapImagetobytearray(bitimage);
            using (var context = new RpgutilityContext())
            {
                var weapon = context.Set<Weapon>();
                Weapon pom = new Weapon { WeaponImage=image,Name=name,Type=type,Quantity=quantity,Description=description,Damage=damage, CharacterId = _character.CharacterId };
                //Act pom = new Act { Name = $"Akt {Acts.Count()}", Description = "Testowe", CampaignId = _campaign.CampaignId };
                await weapon.AddAsync(pom);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateItem(Item item,BitmapImage image,string name,string description,int quantity)
        {
            byte[] data = ImageEncoder.BitmapImagetobytearray(image);
            using (var context = new RpgutilityContext())
            {
                item.ItemImage = data;
                item.Name=name;
                item.Quantity=quantity;
                item.Description=description;
                context.Update(item);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateWeapon(Weapon weapon, BitmapImage image, string name, string description, int quantity, double damage,string type)
        {
            byte[] data = ImageEncoder.BitmapImagetobytearray(image);
            using (var context = new RpgutilityContext())
            {
                weapon.WeaponImage = data;
                weapon.Name=name;
                weapon.Quantity=quantity;
                weapon.Description=description;
                weapon.Damage=damage;
                weapon.Type=type;
                context.Update(weapon);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateArmor(Armor armor, BitmapImage image, string name, string description, int quantity, string type, double armorvalue)
        {
            byte[] data = ImageEncoder.BitmapImagetobytearray(image);
            using (var context = new RpgutilityContext())
            {
                armor.ArmorImage = data;
                armor.Name=name;
                armor.Quantity=quantity;
                armor.Description=description;
                armor.Type=type;
                armor.Armor1=armorvalue;
                context.Update(armor);
                await context.SaveChangesAsync();
            }
        }
        public async Task AddArmor(BitmapImage bitimage, string name, int quantity, string description,string type,double armorvalue)
        {
            byte[] image = ImageEncoder.BitmapImagetobytearray(bitimage);

            
            using (var context = new RpgutilityContext())
            {
                var armor = context.Set<Armor>();
                Armor pom=new Armor{ArmorImage=image,Name=name,Type=type,Quantity=quantity,Description=description,Armor1=armorvalue, CharacterId = _character.CharacterId };
                //Act pom = new Act { Name = $"Akt {Acts.Count()}", Description = "Testowe", CampaignId = _campaign.CampaignId };
                await armor.AddAsync(pom);
                await context.SaveChangesAsync();
            }
        }
    }
}
