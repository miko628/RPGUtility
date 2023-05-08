using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Act")]
public partial class Act
{
    [Key]
    [Column("act_id")]
    public int ActId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("campaign_id")]
    public int? CampaignId { get; set; }

    [InverseProperty("BattleNavigation")]
    public virtual Battle? Battle { get; set; }

    [ForeignKey("CampaignId")]
    [InverseProperty("Acts")]
    public virtual Campaign? Campaign { get; set; }
}
