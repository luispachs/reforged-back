using System;
using System.Collections.Generic;

namespace nago_reforged_api.Models;

public partial class WeeklySchedule
{
    public long Id { get; set; }

    public long MonthlyScheduleId { get; set; }

    public DateOnly ScheduleDate { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual MonthlySchedule MonthlySchedule { get; set; } = null!;
}
