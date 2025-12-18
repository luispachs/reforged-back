using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class Contact
{
    public long Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long IdProvider { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Provider IdProviderNavigation { get; set; } = null!;
}
