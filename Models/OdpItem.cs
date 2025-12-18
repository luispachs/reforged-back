using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class OdpItem
{
    public long Id { get; set; }

    public long IdOdp { get; set; }

    public long IdProduct { get; set; }

    public decimal? Quantity { get; set; }

    public short? RecipeNumber { get; set; }

    public virtual Odp IdOdpNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual ICollection<OdpProcessBom> OdpProcessBoms { get; set; } = new List<OdpProcessBom>();
}
