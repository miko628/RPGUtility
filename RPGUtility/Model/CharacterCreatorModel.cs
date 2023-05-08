using Microsoft.Win32;
using RPGUtility.Models;
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
