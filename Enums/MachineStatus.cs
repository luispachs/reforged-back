namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum MachineStatus {
    [PgName("ACTIVE")]
    ACTIVE,
    [PgName("INACTIVE")]
    INACTIVE,
    [PgName("MAINTENANCE")]
    MAINTENANCE
}