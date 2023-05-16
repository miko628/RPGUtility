using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

public partial class Statistic
{
    [Key]
    [Column("statistics_id")]
    public int StatisticsId { get; set; }

    [Column("weapon_skill")]
    public int WeaponSkill { get; set; }

    [Column("ballistic_skill")]
    public int BallisticSkill { get; set; }

    [Column("strength")]
    public int Strength { get; set; }

    [Column("toughness")]
    public int Toughness { get; set; }

    [Column("agility")]
    public int Agility { get; set; }

    [Column("intelligence")]
    public int Intelligence { get; set; }

    [Column("willpower")]
    public int Willpower { get; set; }

    [Column("fellowship")]
    public int Fellowship { get; set; }

    [Column("attacks")]
    public int Attacks { get; set; }

    [Column("wounds")]
    public int Wounds { get; set; }

    [Column("health")]
    public int Health { get; set; }

    [Column("strength_bonus")]
    public int StrengthBonus { get; set; }

    [Column("toughness_bonus")]
    public int ToughnessBonus { get; set; }

    [Column("movement")]
    public int Movement { get; set; }

    [Column("magic")]
    public int Magic { get; set; }

    [Column("insanity_points")]
    public int InsanityPoints { get; set; }

    [Column("fate_points")]
    public int FatePoints { get; set; }

    [Column("current_fate_points")]
    public int CurrentFatePoints { get; set; }

    [ForeignKey("StatisticsId")]
    [InverseProperty("Statistic")]
    public virtual Character Statistics { get; set; } = null!;
}
