namespace nago_reforged_api.Enums;
using NpgsqlTypes;
public enum RoleArea {
    [PgName("OPERATIVE")]
    OPERATIVE,
    [PgName("ADMIN")]
    ADMIN
}
