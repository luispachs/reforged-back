namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum StatusEnterprises {
    [PgName("ACTIVE")]
    ACTIVE,
    [PgName("INACTIVE")]
    INACTIVE
}