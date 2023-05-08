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
using RPGUtility.Models;
using Microsoft.Win32;

namespace RPGUtility.Model
{
    class CampaignCreatorModel
    {
        private readonly Campaign? _campagin;
        
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

        public async Task<Campaign> save()
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
                Campaign pom = new Campaign { Name = this.Name, Description = this.Description, GameMaster = this.GameMaster, Year = this.Year };
                await campaigns.AddAsync(pom);
                 //context.Campaigns.AddAsync(campaign);
                await context.SaveChangesAsync();
                return pom;
            }
            //Trace.
            //Trace.WriteLine(key);
        }

       
        public CampaignCreatorModel()
        {
            
        }
    }
}
