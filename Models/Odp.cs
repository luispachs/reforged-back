using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Odp
{
    public long Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public List<string>? OdpItems { get; set; }

    public virtual ICollection<Dpnc> Dpncs { get; set; } = new List<Dpnc>();
}
