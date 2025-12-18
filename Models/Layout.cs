using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Layout
{
    public long Id { get; set; }

    public long MachineId { get; set; }

    public int? PositionX { get; set; }

    public int? PositionY { get; set; }

    public int? PositionZ { get; set; }

    public bool? Visible { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Machine Machine { get; set; } = null!;
}
