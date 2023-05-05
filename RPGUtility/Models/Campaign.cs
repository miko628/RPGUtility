using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPGUtility.Models;

[Table("Campaign")]
public partial class Campaign
{
    [Key]
    [Column("campaign_id")]
    public int CampaignId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("game_master", TypeName = "character varying")]
    public string? GameMaster { get; set; }

    [Column("year", TypeName = "character varying")]
    public string? Year { get; set; }

    [InverseProperty("Campaign")]
    public virtual ICollection<Act> Acts { get; set; } = new List<Act>();

    [InverseProperty("Campaign")]
    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
