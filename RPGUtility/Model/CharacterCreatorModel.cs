using Microsoft.Win32;
using Newtonsoft.Json.Linq;
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

           
            public async Task<Character> Save(BitmapImage image,string name,string race,string gender,string? background, DateOnly birth, double height, double weight, string hair,string eyes,string characteristics,string placebirth,string star,string relatives, string maindelty,string languages,string? career,string? careerpath,string? careerexits,double gold,double silver, double pennies, int[] stats)
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
        public int[] HumanRoll()
        {
            int[] list = new int[16];
            for (int i = 0; i < 8; i++)
            {
                Trace.WriteLine("los  " + Dice.k10());
                Trace.WriteLine("los2  " + Dice.k10());
                list[i] = 0;
                list[i] = 20 + Dice.k10() + Dice.k10();
            }
            int roll = Dice.k10();
            switch(roll)
            {
                case var expression when roll <= 3:
                    list[9] = 10;
                    break;
                case var expression when (roll > 3 && roll < 7):
                    list[9] = 11;
                    break;
                case var expression when (roll > 6 && roll < 10):
                    list[9] = 12;
                    break;
                case 10:
                    list[9] = 13;
                    break;
            }
            list[8] = 1;
            list[10] = list[2] / 10;
            list[11] = list[3] / 10;
            list[12] = 4;
            list[13] = 0;
            list[14] = 0;
            roll = Dice.k10();
            switch(roll)
            {
                case var expression when roll <= 4:
                    list[15] = 2;
                    break;
                case var expression when (roll > 4 && roll < 8):
                    list[15] = 3;
                    break;
                case var expression when (roll > 7 && roll < 11):
                    list[15] = 3;
                    break;
            }
            return list;
        }
        public int[] ElfRoll()
        {
            int[] list = new int[16];
            for (int i = 0; i < 8; i++)
            {
                list[i] = 0;
                list[i] = 20 + Dice.k10() + Dice.k10();
            }
            list[1] += 10;
            list[4] += 10;
            int roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 3:
                    list[9] = 9;
                    break;
                case var expression when (roll > 3 && roll < 7):
                    list[9] = 10;
                    break;
                case var expression when (roll > 6 && roll < 10):
                    list[9] = 11;
                    break;
                case 10:
                    list[9] = 12;
                    break;
            }
            list[8] = 1;
            list[10] = list[2] / 10;
            list[11] = list[3] / 10;
            list[12] = 5;
            list[13] = 0;
            list[14] = 0;
            roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 4:
                    list[15] = 1;
                    break;
                case var expression when (roll > 4 && roll < 8):
                    list[15] = 2;
                    break;
                case var expression when (roll > 7 && roll < 11):
                    list[15] = 2;
                    break;
            }
            return list;
        }
        public int[] HalflingRoll()
        {
            int[] list = new int[16];
            for (int i = 0; i < 8; i++)
            {
               
                list[i] = 0;
                list[i] = 20 + Dice.k10() + Dice.k10();
            }
            list[0] -= 10;
            list[1] += 10;
            list[2] -= 10;
            list[3] -= 10;
            list[4] += 10;
            list[7] += 10;
            int roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 3:
                    list[9] = 8;
                    break;
                case var expression when (roll > 3 && roll < 7):
                    list[9] = 9;
                    break;
                case var expression when (roll > 6 && roll < 10):
                    list[9] = 10;
                    break;
                case 10:
                    list[9] = 11;
                    break;
            }
            list[8] = 1;
            list[10] = list[2] / 10;
            list[11] = list[3] / 10;
            list[12] = 4;
            list[13] = 0;
            list[14] = 0;
            roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 4:
                    list[15] = 2;
                    break;
                case var expression when (roll > 4 && roll < 8):
                    list[15] = 2;
                    break;
                case var expression when (roll > 7 && roll < 11):
                    list[15] = 3;
                    break;
            }
            return list;
        }
        public int[] DefaultRoll()
        {
            int[] list = new int[16];
            for (int i = 0; i < 8; i++)
            {
                list[i] = 0;
                list[i] = 20 + Dice.k10() + Dice.k10();
            }
            list[8] = 1;
            list[9] = 10;
            list[10] = list[2] / 10;
            list[11] = list[3] / 10;
            list[12] = 4;
            list[13] = 0;
            list[14] = 0;
            list[15] = 2;
            return list;
        }
        public int[] DwarfRoll()
        {
            int[] list = new int[16];
            for (int i = 0; i < 8; i++)
            {
                list[i] = 0;
                list[i] = 20 + Dice.k10() + Dice.k10();
            }
            list[0] += 10;
            list[3] += 10;
            list[4] -= 10;
            list[7] -= 10;
            int roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 3:
                    list[9] = 11;
                    break;
                case var expression when (roll > 3 && roll < 7):
                    list[9] = 12;
                    break;
                case var expression when (roll > 6 && roll < 10):
                    list[9] = 13;
                    break;
                case 10:
                    list[9] = 14;
                    break;
            }
            list[8] = 1;
            list[10] = list[2] / 10;
            list[11] = list[3] / 10;
            list[12] = 3;
            list[13] = 0;
            list[14] = 0;
            roll = Dice.k10();
            switch (roll)
            {
                case var expression when roll <= 4:
                    list[15] = 1;
                    break;
                case var expression when (roll > 4 && roll < 8):
                    list[15] = 2;
                    break;
                case var expression when (roll > 7 && roll < 11):
                    list[15] = 3;
                    break;
            }
            return list;
        }

        public int GoldRoll()
        {
            return Dice.k10()+Dice.k10();
        }
        public CharacterCreatorModel(Campaign campaign)
        {
            _campaign = campaign;
            //tutaj bendom 3 wartosci zapamietaj i tutaj dodammy takie ladne zaznaczanie ok ok
            //Talent = new ObservableCollection<string> { "bardzo silny","bardzo szybki","błyskotliwość","bystry wzrok","charyzmatyczny","czuły słuch","geniusz arytmetyczny","krzepki","naśladowca","niezwykle odporny","oburęczność","odporność na choroby","odporność na magię","odporność na truciznę","odporność psychniczna","opanowanie","strzelec wyborowy","szczęście","szósty zmysł" };
            //Skill = new ObservableCollection<string> { "Charakteryzacja ", "Dowodzenie", "Hazard", "Jeździectwo", "Mocna głowa", "Opieka nad zwierzętami", "Plotkowanie", "Pływanie", "Powożenie", "Przekonywanie", "Przeszukiwanie", "Skradanie się", "Spostrzegawczość", "Sztuka przetrwania", "Targowanie", "Ukrywanie się", "Wioślarstwo", "Wspinaczka", "Wycena", "Zastraszanie" };
        }
    }
}
