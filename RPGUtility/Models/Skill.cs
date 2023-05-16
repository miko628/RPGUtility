using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Skill")]
public partial class Skill
{
    [Key]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [Column("character_id")]
    public int? CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Skills")]
    public virtual Character? Character { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("Skill")]
    public virtual SkillCategory SkillNavigation { get; set; } = null!;
}
