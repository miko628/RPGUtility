using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RPGUtility;

public partial class Campaign
{
  

    public int CampaignId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? GameMaster { get; set; }

    public string? Year { get; set; }

    public virtual ICollection<Act> Acts { get; set; } = new List<Act>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
