using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class DpncItem
{
    public long Id { get; set; }

    public long IdDpnc { get; set; }

    public long IdProduct { get; set; }

    public decimal? Quantity { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual ICollection<DpncSolution> DpncSolutions { get; set; } = new List<DpncSolution>();

    public virtual Dpnc IdDpncNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
