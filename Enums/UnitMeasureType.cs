namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum UnitMeasureType {
    [PgName("KG")]
    KG,
    [PgName("CM")]
    CM,
    [PgName("MT")]
    MT,
    [PgName("GR")]
    GR,
    [PgName("ML")]
    ML,
    [PgName("UN")]
    UN
}