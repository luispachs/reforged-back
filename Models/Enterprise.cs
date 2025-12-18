using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Enterprise
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
