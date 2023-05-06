﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class StoryModel
    {
        public Campaign _campaign;
        
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
       
        public async Task Delete(Act act)
        {
            using (var context = new RpgutilityContext())
            {
                //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                context.Acts.Remove(act);
                await context.SaveChangesAsync();
            }
        }
        public StoryModel( Campaign campaign)
        {
            this._campaign =campaign;
            Name = this._campaign.Name;
            Description = this._campaign.Description;
            GameMaster = this._campaign.GameMaster;
            Year= this._campaign.Year;
            //   Name = id.ToString();
            // Database db = Database.GetInstance();
            // Campaign _campaign=db.ReadCampaign(id);
            /*Name = _campaign.name;
            Description=_campaign.description;
            GameMaster = _campaign.game_master;
            Year = _campaign.year;*/
            //async Initialize();
            // _ = Initialize();
        }
        public async Task Initialize()
        {

            using (var context = new RpgutilityContext())
            {
                var campaigns = await context.Campaigns.SingleAsync(b => b.CampaignId == id);
                //Name = campaigns.Find(id);
              //  Name = id;
            }
        }
        public void getCampaign()
        {

        }
       //public 
    }
}
