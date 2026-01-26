using System;
using System.Collections.Generic;
using nago_reforged_api.Enums;

namespace nago_reforged_api.Models;

public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public RoleArea Type { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
