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

    [Column("character_id")]
    public int CharacterId { get; set; }

    [Column("talentcategory_id")]
    public int TalentcategoryId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Talents")]
    public virtual Character Character { get; set; } = null!;

    [ForeignKey("TalentcategoryId")]
    [InverseProperty("Talents")]
    public virtual TalentCategory Talentcategory { get; set; } = null!;
}
