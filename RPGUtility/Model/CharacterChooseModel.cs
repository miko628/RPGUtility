using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class CharacterChooseModel
    {
        private Campaign _campaign;
        public CharacterChooseModel(Campaign campaign)
        {
            _campaign = campaign;
        }
        public async Task Delete(Character character)
        {
            try
            {
                using (var context = new RpgutilityContext())
                {
                    //var pom = context.Campaigns.Where(k=>k.CampaignId==id).First();
                    context.Characters.Remove(character);
                    await context.SaveChangesAsync();
                }
            }
            catch (ArgumentNullException e)
            {

                // the exception above will not be caught here
            }
        }
        public async Task<List<Character>> GetAll()
        {
            List<Character> characters;
            //  Thread.Sleep(10000);
            //Campaigns.Clear();
            using (var context=new RpgutilityContext())
            {
                characters = await context.Characters.Where(b => b.CampaignId == _campaign.CampaignId).OrderBy(b => b.Name).ToListAsync();
                return characters;
            }

}
    }
}
