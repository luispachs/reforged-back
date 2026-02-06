using System;
using System.Collections.Generic;
using nago_reforged_api.Enums;

namespace nago_reforged_api.Models;

public partial class Warehouse
{
    public long Id { get; set; }

    public long IdProvider { get; set; }

    public long IdProduct { get; set; }

    public decimal? QuantityAvailable { get; set; }

    public decimal? QuantityReservate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Provider IdProviderNavigation { get; set; } = null!;
}
