using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class DpncSolution
{
    public long Id { get; set; }

    public long IdDpncItem { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long SolvedBy { get; set; }

    public long? OdpId { get; set; }

    public string? HandToHandFile { get; set; }

    public virtual DpncItem IdDpncItemNavigation { get; set; } = null!;

    public virtual User SolvedByNavigation { get; set; } = null!;
}
