using System;
using System.Collections.Generic;

namespace RPGUtility;

public partial class Act
{
    public int ActId { get; set; }

    public string? Description { get; set; }

    public int? CampaignId { get; set; }

    public virtual Battle? Battle { get; set; }

    public virtual Campaign? Campaign { get; set; }
}
