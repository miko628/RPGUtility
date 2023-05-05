using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class StoryModel
    {
        private Campaign _campaign;
        
        public int id;
        
        public string Name 
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string GameMaster
        {
            get;
            set;
        }

        public string Year
        {
            get;
            set;
        }
        public StoryModel()
        {
            Database db = Database.GetInstance();
           // Campaign _campaign=db.ReadCampaign(id);
            /*Name = _campaign.name;
            Description=_campaign.description;
            GameMaster = _campaign.game_master;
            Year = _campaign.year;*/
        }

        public void getCampaign()
        {

        }
       //public 
    }
}
