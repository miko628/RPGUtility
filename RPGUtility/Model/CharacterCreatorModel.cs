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
        public string Year
        {
            get;
            set;
        }
        public BitmapImage Image
        {
            get;
            set;
        }
        public CharacterCreatorModel()
        {
            
        }
    }
}
