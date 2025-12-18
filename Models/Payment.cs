using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Payment
{
    public long Id { get; set; }

    public long IdBuyOrder { get; set; }

    public long IdServiceOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal? Amount { get; set; }

    public virtual BuyOrder IdBuyOrderNavigation { get; set; } = null!;

    public virtual ServiceOrder IdServiceOrderNavigation { get; set; } = null!;
}
