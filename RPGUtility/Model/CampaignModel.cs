using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
namespace RPGUtility.Model
{
    class CampaignModel
    {
        private List<Campaign> campaigns;
         
        //public ObservableCollection<Campaign> Campaigns { get; set; }
        public CampaignModel()
        {
            //Campaigns = new ObservableCollection<Campaign>();
            campaigns = new List<Campaign>();
        }
        public async Task Delete(Campaign campaign)
        {
            try
            { 
            using (var context = new RpgutilityContext())
            {
                //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                context.Campaigns.Remove(campaign);
                await context.SaveChangesAsync();
            }
            }
            catch (ArgumentNullException e)
            {

                // the exception above will not be caught here
            }
            //await GetAll();
        }
        public async Task<List<Campaign>> GetAll()
        {
          //  Thread.Sleep(10000);
            //Campaigns.Clear();
            using (var context=new RpgutilityContext())
            {
                campaigns = await context.Campaigns.OrderBy(b => b.Name).ToListAsync();
                return campaigns;
            }
            /*foreach(var item in campaigns)
            {
                *//*Trace.WriteLine($"Name: {item.Name}");
                Trace.WriteLine($"Description: {item.Description}");
                Trace.WriteLine($"GameMaster: {item.GameMaster}");
                Trace.WriteLine($"Year: {item.Year}");*//*
                Campaigns.Add(item);
            }
           foreach(var item in Campaigns)
            {
                Trace.WriteLine($"Name: {item.Name}");
                Trace.WriteLine($"Description: {item.Description}");
                Trace.WriteLine($"GameMaster: {item.GameMaster}");
                Trace.WriteLine($"Year: {item.Year}");
            }*/
        }
    }
}
