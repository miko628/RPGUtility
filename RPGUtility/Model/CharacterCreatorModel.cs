using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility.Model
{
    class CharacterCreatorModel
    {
        private Character? _character;
        public string CharacterName
        {
            get;
            set;
        }

        public string CurrentCarrer
        {
            get;
            set;
        }
        public string PreviousCarrer
        {
            get;
            set;
        }
        public string PlayerName
        {
            get;
            set;
        }
        public string GameMaster
        {
            get;
            set;
        }
        public string Campaign
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string Background
        {
            get;
            set;
        }
        public string Eyes
        {
            get;
            set;
        }
        public float Weight
        {
            get;
            set;
        }
        public string Hair
        {
            get;
            set;
        }
        public float Height
        {
            get;
            set;
        }
        public string Star
        {
            get;
            set;
        }
        public string Relatives
        {
            get;
            set;
        }
        public string BirthPlace
        {
            get;
            set;
        }
        public string Characteristics
        {
            get;
            set;
        }
        public string Main_Delty
        {
            get;
            set;
        }
        public string CareerPath
            {
            get;
            set;
}
        public float Gold
        {
            get;
            set;
        }
        public float Silver
        {
            get;
            set;
        }
        public string Languages
        {
            get;
            set;
        }
        public float Pennies
        {
            get;
            set;
        }
        public BitmapImage Image
        {
            get;
            set;
        }

        public ObservableCollection<string> Race { get; set; }

           
            public void Save()
        {
            //this._character = new Character(CharacterName, Race., Gender, Background,Year,Height,Weight,Hair,Eyes,Characteristics,BirthPlace,Star,Relatives,Main_Delty,Languages,CurrentCarrer,CareerPath,PreviousCarrer,Gold,Silver,Pennies);
            //this._character.GetAll();
           // this._character.Stats();
          //  Database db=Database.GetInstance();
           // db.InsertCharacter(_character);
           // db.Close();
        }
        public CharacterCreatorModel()
        {
            //tutaj bendom 3 wartosci zapamietaj i tutaj dodammy takie ladne zaznaczanie ok ok
            Race = new ObservableCollection<String> { "Charakteryzacja ", "Dowodzenie", "Hazard", "Jeździectwo", "Mocna głowa", "Opieka nad zwierzętami", "Plotkowanie", "Pływanie", "Powożenie", "Przekonywanie", "Przeszukiwanie", "Skradanie się", "Spostrzegawczość", "Sztuka przetrwania", "Targowanie", "Ukrywanie się", "Wioślarstwo", "Wspinaczka", "Wycena", "Zastraszanie" };
        }
    }
}
