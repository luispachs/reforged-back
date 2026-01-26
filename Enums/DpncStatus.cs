namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum DpncStatus {
    [PgName("PENDING")]
    PENDING,
    [PgName("COMPLETED")]
    COMPLETED
}