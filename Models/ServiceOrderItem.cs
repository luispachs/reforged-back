using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class ServiceOrderItem
{
    public long Id { get; set; }

    public long IdServiceOrder { get; set; }

    public long IdProduct { get; set; }

    public long IdService { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? QuantityReceived { get; set; }

    public DateTime? RecievedDate { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;

    public virtual ServiceOrder IdServiceOrderNavigation { get; set; } = null!;
}
