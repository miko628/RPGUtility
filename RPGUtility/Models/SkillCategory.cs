using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("SkillCategory")]
public partial class SkillCategory
{
    [Key]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [InverseProperty("SkillNavigation")]
    public virtual Skill? Skill { get; set; }
}
