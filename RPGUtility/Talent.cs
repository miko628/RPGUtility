using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Talent
{
    public int TalentId { get; set; }

    public string? Description { get; set; }

    public int? CharacterId { get; set; }

    public virtual Character? Character { get; set; }
}
