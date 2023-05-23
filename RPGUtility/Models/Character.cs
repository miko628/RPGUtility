using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Character")]
public partial class Character
{
    [Key]
    [Column("character_id")]
    public int CharacterId { get; set; }

    [Column("character_image")]
    public byte[] CharacterImage { get; set; } = null!;

    [Column("name", TypeName = "character varying")]
    public string Name { get; set; } = null!;

    [Column("playername", TypeName = "character varying")]
    public string Playername { get; set; } = null!;

    [Column("race", TypeName = "character varying")]
    public string Race { get; set; } = null!;

    [Column("gender", TypeName = "character varying")]
    public string Gender { get; set; } = null!;

    [Column("age")]
    public int Age { get; set; }

    [Column("height")]
    public double Height { get; set; }

    [Column("weight")]
    public double Weight { get; set; }

    [Column("hair", TypeName = "character varying")]
    public string Hair { get; set; } = null!;

    [Column("eyes", TypeName = "character varying")]
    public string Eyes { get; set; } = null!;

    [Column("characteristics")]
    public string? Characteristics { get; set; }

    [Column("place_birth", TypeName = "character varying")]
    public string? PlaceBirth { get; set; }

    [Column("star_sign", TypeName = "character varying")]
    public string StarSign { get; set; } = null!;

    [Column("relatives", TypeName = "character varying")]
    public string? Relatives { get; set; }

    [Column("gold_crowns")]
    public double GoldCrowns { get; set; }

    [Column("silver_shillings")]
    public double SilverShillings { get; set; }

    [Column("brass_penniews")]
    public double BrassPenniews { get; set; }

    [Column("campaign_id")]
    public int CampaignId { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Armor> Armors { get; set; } = new List<Armor>();

    [ForeignKey("CampaignId")]
    [InverseProperty("Characters")]
    public virtual Campaign Campaign { get; set; } = null!;

    [InverseProperty("Character")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    [InverseProperty("Character")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    [InverseProperty("Statistics")]
    public virtual Statistic? Statistic { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Talent> Talents { get; set; } = new List<Talent>();

    [InverseProperty("Character")]
    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}
