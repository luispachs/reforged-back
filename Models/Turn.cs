using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Turn
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
