using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Battle
{
    public int BattleId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public virtual Act BattleNavigation { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
