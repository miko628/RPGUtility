using ControlzEx.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class StoryModel
    {
        private Campaign _campaign;
        private List<Act> acts;
        
        //public ObservableCollection<Act> Acts { get; set; }
        
       
        public async Task Delete(Act act)
        {
            using (var context = new RpgutilityContext())
            {
                //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                context.Acts.Remove(act);
                await context.SaveChangesAsync();
            }
            //await GetAll();
        }

        public async Task EditCampaign(Campaign _campaign)
        {
            using (var context = new RpgutilityContext())
            {
                //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                context.Campaigns.Remove(_campaign);
                await context.SaveChangesAsync();
            }
        }

        public StoryModel( Campaign campaign)
        {
            this._campaign =campaign;
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
        public async Task AddAct(int number)
        {
            using (var context=new RpgutilityContext())
            {
                var act = context.Set<Act>();
                Act pom = new Act { Name = $"Akt {number}", Description = "",CampaignId=_campaign.CampaignId };
                await act.AddAsync(pom);
                await context.SaveChangesAsync();
            }
           // await GetAll();
        }
        public async Task Initialize()
        {

            using (var context = new RpgutilityContext())
            {
                var campaigns = await context.Acts.SingleAsync(b => b.CampaignId == _campaign.CampaignId);
                //Name = campaigns.Find(id);
              //  Name = id;
            }
        }
        public async Task UpdateAct(Act act,string name,string description)
        {
            using (var context = new RpgutilityContext())
            {
                act.Name = name;
                act.Description = description;
                context.Update(act);
               await context.SaveChangesAsync();
            }
        }
        public async Task UpdateCampaign(string name,string description,string gamemaster,string year)
        {
            using (var context = new RpgutilityContext())
            {
                _campaign.Name = name;
                _campaign.Description = description;
                _campaign.GameMaster = gamemaster;
                _campaign.Year = year;
                context.Update(_campaign);
                await context.SaveChangesAsync();
                
            }
        }
        public async Task<List<Act>> GetAll()
        {
           // Acts.Clear();
            using (var context = new RpgutilityContext())
            {
                acts = await context.Acts.Where(b => b.CampaignId == _campaign.CampaignId).OrderBy(a => a.ActId).ToListAsync();
                return acts;
            }
           /* foreach (var item in acts)
            {
                Trace.WriteLine($"Description: {item.Description}");
                Acts.Add(item);
            }*/

        }
        //public 
    }
}
