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
    public int CharacterId { get; set; }

    [Column("skillcategory_id")]
    public int SkillcategoryId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Skills")]
    public virtual Character Character { get; set; } = null!;

    [ForeignKey("SkillcategoryId")]
    [InverseProperty("Skills")]
    public virtual SkillCategory Skillcategory { get; set; } = null!;
}
