using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    internal class Character
    {
        int id;
        string name;
        string race;
        string gender;
        string[] background;
        int birth_year;
        float height;//float mozna
        float weight;
        string hair;
        string eyes;
        string[] characteristics;
        string place_birth;
        string star_sign;
        string relatives;
        string main_delty;
        string[] languages;
        string career;
        string carrer_path;
        string carrer_exits;
        int weapon_skill;
        int ballistic_skill;
        int strenght;
        int toughness;
        int agility;
        int inteligence;
        int willpower;
        int fellowship;
        int attacks;
        int wounds;
        int strength_bonus;
        int toughness_bonus;
        int movement;
        int magic;
        int insanity_points;
        int fate_points;

        public Character(string name)
        {
            this.name = name;

        }
    }
}
