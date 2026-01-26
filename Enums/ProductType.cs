namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ProductType {
    [PgName("PP")]
    PP,
    [PgName("PT")]
    PT,
    [PgName("MP")]
    MP,
    [PgName("INPUT")]
    INPUT,
    [PgName("TOOL")]
    TOOL,
    [PgName("COMBO")]
    COMBO
}