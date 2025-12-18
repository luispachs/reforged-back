using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Profile
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long EnterpriceId { get; set; }

    public decimal SalaryHour { get; set; }

    public long? LeaderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int TurnId { get; set; }

    public int AreaId { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual Enterprise Enterprice { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual Turn Turn { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
