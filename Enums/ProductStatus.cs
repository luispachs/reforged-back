namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ProductStatus {
    [PgName("ACTIVE")]
    ACTIVE,
    [PgName("DISCONTINUED")]
    DISCONTINUED,
    [PgName("INACTIVE")]
    INACTIVE
}