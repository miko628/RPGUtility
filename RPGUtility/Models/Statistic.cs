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
    public int? WeaponSkill { get; set; }

    [Column("ballistic_skill")]
    public int? BallisticSkill { get; set; }

    [Column("strength")]
    public int? Strength { get; set; }

    [Column("toughness")]
    public int? Toughness { get; set; }

    [Column("agility")]
    public int? Agility { get; set; }

    [Column("intelligence")]
    public int? Intelligence { get; set; }

    [Column("willpower")]
    public int? Willpower { get; set; }

    [Column("fellowship")]
    public int? Fellowship { get; set; }

    [Column("advance_weapon_skill")]
    public int? AdvanceWeaponSkill { get; set; }

    [Column("advance_ballistic_skill")]
    public int? AdvanceBallisticSkill { get; set; }

    [Column("advance_strength")]
    public int? AdvanceStrength { get; set; }

    [Column("advance_toughness")]
    public int? AdvanceToughness { get; set; }

    [Column("advance_agility")]
    public int? AdvanceAgility { get; set; }

    [Column("advance_intelligence")]
    public int? AdvanceIntelligence { get; set; }

    [Column("advance_willpower")]
    public int? AdvanceWillpower { get; set; }

    [Column("advance_fellowship")]
    public int? AdvanceFellowship { get; set; }

    [Column("current_weapon_skill")]
    public int? CurrentWeaponSkill { get; set; }

    [Column("current_ballistic_skill")]
    public int? CurrentBallisticSkill { get; set; }

    [Column("current_strength")]
    public int? CurrentStrength { get; set; }

    [Column("current_toughness")]
    public int? CurrentToughness { get; set; }

    [Column("current_agility")]
    public int? CurrentAgility { get; set; }

    [Column("current_intelligence")]
    public int? CurrentIntelligence { get; set; }

    [Column("current_willpower")]
    public int? CurrentWillpower { get; set; }

    [Column("current_fellowship")]
    public int? CurrentFellowship { get; set; }

    [Column("attacks")]
    public int? Attacks { get; set; }

    [Column("wounds")]
    public int? Wounds { get; set; }

    [Column("strength_bonus")]
    public int? StrengthBonus { get; set; }

    [Column("toughness_bonus")]
    public int? ToughnessBonus { get; set; }

    [Column("movement")]
    public int? Movement { get; set; }

    [Column("magic")]
    public int? Magic { get; set; }

    [Column("insanity_points")]
    public int? InsanityPoints { get; set; }

    [Column("fate_points")]
    public int? FatePoints { get; set; }

    [Column("advance_attacks")]
    public int? AdvanceAttacks { get; set; }

    [Column("advance_wounds")]
    public int? AdvanceWounds { get; set; }

    [Column("advance_strength_bonus")]
    public int? AdvanceStrengthBonus { get; set; }

    [Column("advance_toughness_bonus")]
    public int? AdvanceToughnessBonus { get; set; }

    [Column("advance_movement")]
    public int? AdvanceMovement { get; set; }

    [Column("advance_magic")]
    public int? AdvanceMagic { get; set; }

    [Column("advance_insanity_points")]
    public int? AdvanceInsanityPoints { get; set; }

    [Column("advance_fate_points")]
    public int? AdvanceFatePoints { get; set; }

    [Column("current_attacks")]
    public int? CurrentAttacks { get; set; }

    [Column("current_wounds")]
    public int? CurrentWounds { get; set; }

    [Column("current_strength_bonus")]
    public int? CurrentStrengthBonus { get; set; }

    [Column("current_toughness_bonus")]
    public int? CurrentToughnessBonus { get; set; }

    [Column("current_movement")]
    public int? CurrentMovement { get; set; }

    [Column("current_magic")]
    public int? CurrentMagic { get; set; }

    [Column("current_insanity_points")]
    public int? CurrentInsanityPoints { get; set; }

    [Column("current_fate_points")]
    public int? CurrentFatePoints { get; set; }

    [ForeignKey("StatisticsId")]
    [InverseProperty("Statistic")]
    public virtual Character Statistics { get; set; } = null!;
}
