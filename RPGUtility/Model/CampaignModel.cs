using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
namespace RPGUtility.Model
{
    class CampaignModel
    {
        private List<Campaign> campaigns;
         
        public ObservableCollection<Campaign> Campaigns { get; set; }
        public CampaignModel()
        {
            Campaigns = new ObservableCollection<Campaign>();
            campaigns = new List<Campaign>();
        }
        public async Task Delete(Campaign campaign)
        {
            using (var context = new RpgutilityContext())
            {
                //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                context.Campaigns.Remove(campaign);
                await context.SaveChangesAsync();
            }
        }
        public async Task GetAll()
        {
            
            using (var context=new RpgutilityContext())
            {
                campaigns = await context.Campaigns.ToListAsync();
            }
            foreach(var item in campaigns)
            {
                Trace.WriteLine($"Name: {item.Name}");
                Trace.WriteLine($"Description: {item.Description}");
                Trace.WriteLine($"GameMaster: {item.GameMaster}");
                Trace.WriteLine($"Year: {item.Year}");
                Campaigns.Add(item);
            }
           
        }
    }
}
