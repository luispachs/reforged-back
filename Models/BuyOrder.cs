using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class BuyOrder
{
    public long Id { get; set; }

    public long IdProvider { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BuyOrderItem> BuyOrderItems { get; set; } = new List<BuyOrderItem>();

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
