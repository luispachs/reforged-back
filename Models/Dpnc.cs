using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Dpnc
{
    public long Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public long? Odp { get; set; }

    public virtual ICollection<DpncItem> DpncItems { get; set; } = new List<DpncItem>();

    public virtual Odp? OdpNavigation { get; set; }
}
