using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class MonthlySchedule
{
    public long Id { get; set; }

    public long ReferenceId { get; set; }

    public DateOnly ScheduleDate { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Product Reference { get; set; } = null!;

    public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; } = new List<WeeklySchedule>();
}
