using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RPGUtility.Model
{
    class CampaignCreatorModel
    {
        private Campaign? _campagin;
       // public int? key;
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

        public void save()
        {
            //_campagin = new Campaign(Name, Description, GameMaster, Year);
            //this._character.GetAll();
            // this._character.Stats();
            //  Database db=Database.GetInstance();
            //key = db.InsertCampaign(_campagin);
            // db.Close();
            
            using (var context=new RpgutilityContext())
            {
                var campaigns = context.Set<Campaign>();
                 campaigns.Add(new Campaign { /*CampaignId=556,*/Name = this.Name, Description = this.Description, GameMaster = this.GameMaster, Year =this.Year});
                 //context.Campaigns.AddAsync(campaign);
                 context.SaveChanges();
            }
        }
        public CampaignCreatorModel()
        {
            
        }
    }
}
