using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class OdpProcessBomRegister
{
    public long Id { get; set; }

    public long IdOdpProcessBom { get; set; }

    public long IdMachine { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal? Quantity { get; set; }

    public long UserId { get; set; }

    public virtual Machine IdMachineNavigation { get; set; } = null!;

    public virtual OdpProcessBom IdOdpProcessBomNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
