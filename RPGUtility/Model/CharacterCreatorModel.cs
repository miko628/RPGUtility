using Microsoft.Win32;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.Model
{
    class CharacterCreatorModel
    {
        private Campaign _campaign;
        public BitmapImage Image
        {
            get;
            set;
        }

        public ObservableCollection<string> Race { get; set; }

           
            public async Task<Character> Save(BitmapImage image,string name,string race,string gender,string? background, DateOnly birth, double height, double weight, string hair,string eyes,string characteristics,string placebirth,string star,string relatives, string maindelty,string languages,string? career,string? careerpath,string? careerexits,double gold,double silver, double pennies, int[] stats, int[] stats1, int[] stats2)
        {
            byte[] data=ImageEncoder.BitmapImagetobytearray(image);
            using (var context = new RpgutilityContext())
            {
                var characters = context.Set<Character>();
                //Statistic stat = new Statistic { WeaponSkill = stats[0], };
                Character pom = new Character { CharacterImage = data, Name = name, Race = race, Gender = gender, Background = background, BirthYear = birth, Height = height, Weight = weight, Hair = hair, Eyes = eyes, Characteristics = characteristics, PlaceBirth = placebirth, StarSign = star, Relatives = relatives, MainDelty = maindelty, Languages = languages, Career = career, CarrerPath = careerpath, CarrerExits = careerexits, GoldCrowns = gold, SilverShillings = silver, BrassPenniews = pennies, CampaignId = _campaign.CampaignId};

                await characters.AddAsync(pom);
                //context.Campaigns.AddAsync(campaign);
                await context.SaveChangesAsync();
                return pom;
            }
        }
        public CharacterCreatorModel(Campaign campaign)
        {
            _campaign = campaign;
            //tutaj bendom 3 wartosci zapamietaj i tutaj dodammy takie ladne zaznaczanie ok ok
            Race = new ObservableCollection<String> { "Charakteryzacja ", "Dowodzenie", "Hazard", "Jeździectwo", "Mocna głowa", "Opieka nad zwierzętami", "Plotkowanie", "Pływanie", "Powożenie", "Przekonywanie", "Przeszukiwanie", "Skradanie się", "Spostrzegawczość", "Sztuka przetrwania", "Targowanie", "Ukrywanie się", "Wioślarstwo", "Wspinaczka", "Wycena", "Zastraszanie" };
        }
    }
}
