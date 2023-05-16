using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Armor")]
public partial class Armor
{
    [Key]
    [Column("armor_id")]
    public int ArmorId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string Name { get; set; } = null!;

    [Column("armor_image")]
    public byte[] ArmorImage { get; set; } = null!;

    [Column("type", TypeName = "character varying")]
    public string Type { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("armor")]
    public double Armor1 { get; set; }

    [Column("character_id")]
    public int? CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Armors")]
    public virtual Character? Character { get; set; }
}
