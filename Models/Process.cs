using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Process
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ProcessBom> ProcessBoms { get; set; } = new List<ProcessBom>();
}
