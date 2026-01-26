namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum OdpStatus {
    [PgName("IN_PROCESS")]
    IN_PROCESS,
    [PgName("COMPLETED")]
    COMPLETED,
    [PgName("CANCELLED")]
    CANCELLED,
    [PgName("FREEDOM")]
    FREEDOM,
    [PgName("PENDING")]
    PENDING
}