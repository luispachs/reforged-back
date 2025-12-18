using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Bom
{
    public long IdReference { get; set; }

    public long IdComponent { get; set; }

    public decimal? Quantity { get; set; }

    public short? Recipe { get; set; }

    public virtual Product IdComponentNavigation { get; set; } = null!;

    public virtual Product IdReferenceNavigation { get; set; } = null!;
}
