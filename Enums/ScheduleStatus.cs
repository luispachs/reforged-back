namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ScheduleStatus {
    [PgName("PENDING")]
    PENDING,
    [PgName("IN_PROGRESS")]
    IN_PROGRESS,
    [PgName("COMPLETED")]
    COMPLETED,
    [PgName("CANCELLED")]
    CANCELLED
}