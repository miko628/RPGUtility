using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Statistic
{
    public int StatisticsId { get; set; }

    public int? WeaponSkill { get; set; }

    public int? BallisticSkill { get; set; }

    public int? Strength { get; set; }

    public int? Toughness { get; set; }

    public int? Agility { get; set; }

    public int? Intelligence { get; set; }

    public int? Willpower { get; set; }

    public int? Fellowship { get; set; }

    public int? AdvanceWeaponSkill { get; set; }

    public int? AdvanceBallisticSkill { get; set; }

    public int? AdvanceStrength { get; set; }

    public int? AdvanceToughness { get; set; }

    public int? AdvanceAgility { get; set; }

    public int? AdvanceIntelligence { get; set; }

    public int? AdvanceWillpower { get; set; }

    public int? AdvanceFellowship { get; set; }

    public int? CurrentWeaponSkill { get; set; }

    public int? CurrentBallisticSkill { get; set; }

    public int? CurrentStrength { get; set; }

    public int? CurrentToughness { get; set; }

    public int? CurrentAgility { get; set; }

    public int? CurrentIntelligence { get; set; }

    public int? CurrentWillpower { get; set; }

    public int? CurrentFellowship { get; set; }

    public int? Attacks { get; set; }

    public int? Wounds { get; set; }

    public int? StrengthBonus { get; set; }

    public int? ToughnessBonus { get; set; }

    public int? Movement { get; set; }

    public int? Magic { get; set; }

    public int? InsanityPoints { get; set; }

    public int? FatePoints { get; set; }

    public int? AdvanceAttacks { get; set; }

    public int? AdvanceWounds { get; set; }

    public int? AdvanceStrengthBonus { get; set; }

    public int? AdvanceToughnessBonus { get; set; }

    public int? AdvanceMovement { get; set; }

    public int? AdvanceMagic { get; set; }

    public int? AdvanceInsanityPoints { get; set; }

    public int? AdvanceFatePoints { get; set; }

    public int? CurrentAttacks { get; set; }

    public int? CurrentWounds { get; set; }

    public int? CurrentStrengthBonus { get; set; }

    public int? CurrentToughnessBonus { get; set; }

    public int? CurrentMovement { get; set; }

    public int? CurrentMagic { get; set; }

    public int? CurrentInsanityPoints { get; set; }

    public int? CurrentFatePoints { get; set; }

    public virtual Character Statistics { get; set; } = null!;
}
