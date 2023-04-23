using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public string Race
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
        public BitmapImage Image
        {
            get;
            set;
        }
        public void Save()
        {
            this._character = new Character(CharacterName,Race,Gender,"ok",Year,Height,Weight,Hair,Eyes, Characteristics,BirthPlace,Star,Relatives,Campaign,"jenzyk", PreviousCarrer,CurrentCarrer,"dupa");
            this._character.get();
        }
        public CharacterCreatorModel()
        {
            
        }
    }
}
