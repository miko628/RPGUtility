using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    internal class Character
    {
        int? id;
        string name;
        string race;
        string? gender;
        string? background;//kilka
        string? description;//kilka
        int birth_year;
        float height;//float mozna
        float weight;
        string hair;
        string  eyes;
        string? characteristics;//kilka
        string place_birth;
        string star_sign;
        string? relatives;
        string? main_delty;
        string? languages;//kilka
        string? career;
        string? career_path;
        string? career_exits;
        int? weapon_skill;
        int? ballistic_skill;
        int? strength;
        int? toughness;
        int? agility;
        int? inteligence;
        int? willpower;
        int? fellowship;
        int? attacks;
        int?  wounds;
        int? strength_bonus;
        int? toughness_bonus;
        int? movement;
        int? magic;
        int? insanity_points;
        int? fate_points;

        public Character(string name,string race, string gender, string background,int birth_year,float height, float weight, string hair, string eyes, string characteristics,string place_birth, string star_sign, string relatives, string main_delty, string languages,string career,string career_path, string career_exits)
        {
            this.name = name;
            this.race = race;
            this.gender = gender;
            this.background = background;
            this.birth_year = birth_year;
            this.height = height;
            this.weight = weight;
            this.hair = hair;
            this.eyes = eyes;
            this.characteristics = characteristics;
            this.place_birth = place_birth;
            this.star_sign = star_sign;
            this.relatives = relatives;
            this.main_delty = main_delty;
            this.career = career;
            this.career_path = career_path;
            this.career_exits = career_exits;
        }
        public void get()
        {
            Trace.WriteLine(this.name);
            Trace.WriteLine(this.race);
            Trace.WriteLine(this.gender);
            Trace.WriteLine(this.background);
            Trace.WriteLine(this.birth_year);
            Trace.WriteLine(this.height);
            Trace.WriteLine(this.weight);
            Trace.WriteLine(this.hair);
            Trace.WriteLine(this.eyes);
            Trace.WriteLine(this.characteristics);
            Trace.WriteLine(this.place_birth);
            Trace.WriteLine(this.star_sign);
            Trace.WriteLine(this.relatives);
            Trace.WriteLine(this.main_delty);
            Trace.WriteLine(this.career);
            Trace.WriteLine(this.career_path);
            Trace.WriteLine(this.career_exits);


        }
        public void Statistics(int weapon_skill,int ballistic_skill,int strength, int toughness,int agility,int inteligence,int willpower,int fellowship,int attacks, int wounds, int strength_bouns, int movement,int magic, int insanity_points,int fate_points)
        {
            this.weapon_skill = weapon_skill;
            this.ballistic_skill= ballistic_skill;
            this.strength = strength;
            this.toughness = toughness;
            this.agility = agility;
            this.inteligence = inteligence;
            this.willpower = willpower;
            this.fellowship = fellowship;
            this.attacks = attacks;
            this.wounds = wounds;
            this.strength_bonus = strength_bouns;
            this.movement = movement;
            this.magic = magic;
            this.insanity_points = insanity_points;
            this.fate_points = fate_points;
        }
        public void health(int value)
        {
            this.wounds-=value;
        }
        public void lucky_point()
        {
            this.fate_points -= 1;
        }

    }
}
