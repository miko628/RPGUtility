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
    public byte[]? CharacterImage { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("race", TypeName = "character varying")]
    public string? Race { get; set; }

    [Column("gender", TypeName = "character varying")]
    public string? Gender { get; set; }

    [Column("background")]
    public string? Background { get; set; }

    [Column("birth_year")]
    public DateOnly? BirthYear { get; set; }

    [Column("height")]
    public double? Height { get; set; }

    [Column("weight")]
    public double? Weight { get; set; }

    [Column("hair", TypeName = "character varying")]
    public string? Hair { get; set; }

    [Column("eyes", TypeName = "character varying")]
    public string? Eyes { get; set; }

    [Column("characteristics")]
    public string? Characteristics { get; set; }

    [Column("place_birth", TypeName = "character varying")]
    public string? PlaceBirth { get; set; }

    [Column("star_sign", TypeName = "character varying")]
    public string? StarSign { get; set; }

    [Column("relatives", TypeName = "character varying")]
    public string? Relatives { get; set; }

    [Column("main_delty", TypeName = "character varying")]
    public string? MainDelty { get; set; }

    [Column("languages")]
    public string? Languages { get; set; }

    [Column("career", TypeName = "character varying")]
    public string? Career { get; set; }

    [Column("carrer_path", TypeName = "character varying")]
    public string? CarrerPath { get; set; }

    [Column("carrer_exits", TypeName = "character varying")]
    public string? CarrerExits { get; set; }

    [Column("gold_crowns")]
    public double? GoldCrowns { get; set; }

    [Column("silver_shillings")]
    public double? SilverShillings { get; set; }

    [Column("brass_penniews")]
    public double? BrassPenniews { get; set; }

    [Column("campaign_id")]
    public int? CampaignId { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<Armor> Armors { get; set; } = new List<Armor>();

    [ForeignKey("CampaignId")]
    [InverseProperty("Characters")]
    public virtual Campaign? Campaign { get; set; }

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

    [ForeignKey("CharacterId")]
    [InverseProperty("Characters")]
    public virtual ICollection<Battle> Battles { get; set; } = new List<Battle>();
}
