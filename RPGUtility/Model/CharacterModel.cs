using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace RPGUtility.Model
{
    internal class CharacterModel
    {
        public BitmapImage Image
        {
            get;
            set;
        }
        public CharacterModel()
        {
            
        }
        public async Task<Statistic> FatePoint(Statistic stats)
        {
            using (var context = new RpgutilityContext())
            {

                stats.CurrentFatePoints -= 1;
                context.Update(stats);
                await context.SaveChangesAsync();
                return stats;
            }
        }

        public async Task<Statistic> ResetFatePoint(Statistic stats)
        {
            using (var context = new RpgutilityContext())
            {

                stats.CurrentFatePoints =stats.FatePoints;
                context.Update(stats);
                await context.SaveChangesAsync();
                return stats;
            }
        }
        public async Task<Statistic> GetStats(Character character)
        {
            using (var context = new RpgutilityContext())
            {
                Statistic statList = await context.Statistics.Where(b => b.StatisticsId == character.CharacterId).FirstAsync();
                return statList;
            }
        }
    }
}
