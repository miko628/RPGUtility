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
    public string? Name { get; set; }

    [Column("armor_image")]
    public byte[]? ArmorImage { get; set; }

    [Column("type", TypeName = "character varying")]
    public string? Type { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("head")]
    public double? Head { get; set; }

    [Column("chestplate")]
    public double? Chestplate { get; set; }

    [Column("leggings")]
    public double? Leggings { get; set; }

    [Column("boots")]
    public double? Boots { get; set; }

    [Column("character_id")]
    public int? CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Armors")]
    public virtual Character? Character { get; set; }
}
