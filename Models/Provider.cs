using System;
using System.Collections.Generic;
using nago_reforged_api.Enums;

namespace nago_reforged_api.Models;

public partial class Provider
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Nit { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
    public ProviderType Type { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; set; } = new List<BuyOrder>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
