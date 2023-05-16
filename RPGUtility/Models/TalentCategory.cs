using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("TalentCategory")]
public partial class TalentCategory
{
    [Key]
    [Column("talent_id")]
    public int TalentId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [InverseProperty("TalentNavigation")]
    public virtual Talent? Talent { get; set; }
}
