namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum OdpType {
    [PgName("BASIC")]
    BASIC,
    [PgName("COMBO")]
    COMBO,
    [PgName("PAINTING")]
    PAINTING,
    [PgName("DPNC BASIC")]
    DPNC_BASIC,
    [PgName("DPNC PAINTING")]
    DPNC_PAINTING
}