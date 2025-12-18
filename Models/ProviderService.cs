using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class ProviderService
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public long? ServiceId { get; set; }

    public long ProviderId { get; set; }

    public decimal? Value { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Provider Provider { get; set; } = null!;

    public virtual Service? Service { get; set; }
}
