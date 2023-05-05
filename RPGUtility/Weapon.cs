﻿using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Weapon
{
    public int WeaponId { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public double? Damage { get; set; }

    public int? CharacterId { get; set; }

    public virtual Character? Character { get; set; }
}
