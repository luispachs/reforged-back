using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class OdpProcessBom
{
    public long Id { get; set; }

    public long IdProcessBom { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ProcessBom IdProcessBomNavigation { get; set; } = null!;

    public virtual ICollection<OdpProcessBomRegister> OdpProcessBomRegisters { get; set; } = new List<OdpProcessBomRegister>();
}
