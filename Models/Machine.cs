using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Machine
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<decimal>? Position { get; set; }

    public string? Brand { get; set; }

    public DateTime? LastMaintenance { get; set; }

    public string? Model { get; set; }

    public virtual ICollection<Layout> Layouts { get; set; } = new List<Layout>();

    public virtual ICollection<OdpProcessBomRegister> OdpProcessBomRegisters { get; set; } = new List<OdpProcessBomRegister>();
}
