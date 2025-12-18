using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class ServiceOrder
{
    public long Id { get; set; }

    public long IdProvider { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; } = new List<ServiceOrderItem>();
}
