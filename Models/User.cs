using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class User
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<DpncSolution> DpncSolutions { get; set; } = new List<DpncSolution>();

    public virtual ICollection<OdpProcessBomRegister> OdpProcessBomRegisters { get; set; } = new List<OdpProcessBomRegister>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
