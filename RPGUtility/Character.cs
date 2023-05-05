using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Character
{
    public int CharacterId { get; set; }

    public byte[]? CharacterImage { get; set; }

    public string? Name { get; set; }

    public string? Race { get; set; }

    public string? Gender { get; set; }

    public string? Background { get; set; }

    public DateOnly? BirthYear { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? Hair { get; set; }

    public string? Eyes { get; set; }

    public string? Characteristics { get; set; }

    public string? PlaceBirth { get; set; }

    public string? StarSign { get; set; }

    public string? Relatives { get; set; }

    public string? MainDelty { get; set; }

    public string? Languages { get; set; }

    public string? Career { get; set; }

    public string? CarrerPath { get; set; }

    public string? CarrerExits { get; set; }

    public double? GoldCrowns { get; set; }

    public double? SilverShillings { get; set; }

    public double? BrassPenniews { get; set; }

    public int? CampaignId { get; set; }

    public virtual ICollection<Armor> Armors { get; set; } = new List<Armor>();

    public virtual Campaign? Campaign { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual Statistic? Statistic { get; set; }

    public virtual ICollection<Talent> Talents { get; set; } = new List<Talent>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();

    public virtual ICollection<Battle> Battles { get; set; } = new List<Battle>();
}
