using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Battle")]
public partial class Battle
{
    [Key]
    [Column("battle_id")]
    public int BattleId { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [ForeignKey("BattleId")]
    [InverseProperty("Battle")]
    public virtual Act BattleNavigation { get; set; } = null!;

    [ForeignKey("BattleId")]
    [InverseProperty("Battles")]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
