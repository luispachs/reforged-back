using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class BuyOrderItem
{
    public long Id { get; set; }

    public long IdBuyOrder { get; set; }

    public long IdProduct { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? QuantityReceived { get; set; }

    public DateTime? RecievedDate { get; set; }

    public virtual BuyOrder IdBuyOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
