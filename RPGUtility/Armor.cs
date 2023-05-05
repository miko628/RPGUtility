using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Armor
{
    public int ArmorId { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public double? Head { get; set; }

    public double? Chestplate { get; set; }

    public double? Leggings { get; set; }

    public double? Boots { get; set; }

    public int? CharacterId { get; set; }

    public virtual Character? Character { get; set; }
}
