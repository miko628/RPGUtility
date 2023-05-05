using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Talent")]
public partial class Talent
{
    [Key]
    [Column("talent_id")]
    public int TalentId { get; set; }

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [Column("character_id")]
    public int? CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Talents")]
    public virtual Character? Character { get; set; }
}
