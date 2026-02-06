using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Reference { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public decimal? SalePrice { get; set; }

    public decimal? X { get; set; }

    public decimal? Y { get; set; }

    public decimal? Z { get; set; }

    public decimal? MinimalPoint { get; set; }

    public decimal? MaximalPoint { get; set; }

    public string? Gtin { get; set; }

    public string? Image { get; set; }

    public decimal? Weight { get; set; }

    public virtual ICollection<BuyOrderItem> BuyOrderItems { get; set; } = new List<BuyOrderItem>();

    public virtual ICollection<DpncItem> DpncItems { get; set; } = new List<DpncItem>();

    public virtual ICollection<MonthlySchedule> MonthlySchedules { get; set; } = new List<MonthlySchedule>();

    public virtual ICollection<ProcessBom> ProcessBoms { get; set; } = new List<ProcessBom>();

    public virtual ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    public virtual ICollection<ServiceOrderItem> ServiceOrderItems { get; set; } = new List<ServiceOrderItem>();
}
