using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class ProcessBom
{
    public long Id { get; set; }

    public long IdReference { get; set; }

    public short RecipeNumber { get; set; }

    public long ProcessId { get; set; }

    public decimal? Sam { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product IdReferenceNavigation { get; set; } = null!;

    public virtual ICollection<OdpProcessBom> OdpProcessBoms { get; set; } = new List<OdpProcessBom>();

    public virtual Process Process { get; set; } = null!;
}
