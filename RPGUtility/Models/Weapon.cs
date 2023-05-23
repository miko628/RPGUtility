using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Weapon")]
public partial class Weapon
{
    [Key]
    [Column("weapon_id")]
    public int WeaponId { get; set; }

    [Column("weapon_image")]
    public byte[] WeaponImage { get; set; } = null!;

    [Column("name", TypeName = "character varying")]
    public string Name { get; set; } = null!;

    [Column("type", TypeName = "character varying")]
    public string Type { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("damage")]
    public double Damage { get; set; }

    [Column("character_id")]
    public int CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("Weapons")]
    public virtual Character Character { get; set; } = null!;
}
