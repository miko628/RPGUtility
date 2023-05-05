using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Item
{
    public int ItemId { get; set; }

    public string? Name { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public int? CharacterId { get; set; }

    public virtual Character? Character { get; set; }
}
