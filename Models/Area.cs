using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Area
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
