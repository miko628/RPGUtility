using Microsoft.EntityFrameworkCore;
using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.Model
{
    internal class TestModel
    {
        public TestModel()
        {
            
        }
        public async Task<List<SkillCategory>> GetSkills(Character character)
        {
            using (var context = new RpgutilityContext())
            {
                List<Skill> SkillList = await context.Skills.Where(b => b.CharacterId == character.CharacterId).ToListAsync();
                List<SkillCategory> pom = await context.SkillCategories.Where(b => SkillList.Select(s => s.SkillcategoryId).Contains(b.SkillId)).ToListAsync();

                // List<SkillCategory> pom = await context.SkillCategories.Where(b=>b.SkillId=SkillList.)
                /*  foreach (var skill in SkillList) 
                  {
                      pom.Add(skill.Skillcategory);
                  }*/
                return pom;
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
