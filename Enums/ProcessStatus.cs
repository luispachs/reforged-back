namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ProcessStatus {
    [PgName("ACTIVE")]
    ACTIVE,
    [PgName("INACTIVE")]
    INACTIVE
}