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
        public async Task AddArmor(BitmapImage bitimage, string name, int quantity, string description,string type,double armorvalue)
        {
            byte[] image = ImageEncoder.BitmapImagetobytearray(bitimage);
            double head = armorvalue;
            double chest = armorvalue;
            double leggings = armorvalue;
            double boots = armorvalue;
            using (var context = new RpgutilityContext())
            {
                var armor = context.Set<Armor>();
                Armor pom=new Armor{ArmorImage=image,Type=type,Quantity=quantity,Description=description,Head=head,Chestplate=chest,Leggings=leggings,Boots=boots, CharacterId = _character.CharacterId };
                //Act pom = new Act { Name = $"Akt {Acts.Count()}", Description = "Testowe", CampaignId = _campaign.CampaignId };
                await armor.AddAsync(pom);
                await context.SaveChangesAsync();
            }
        }
    }
}
