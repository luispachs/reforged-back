namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ProviderCalification {
    [PgName("EXCELLENT")]
    EXCELLENT,
    [PgName("GOOD")]
    GOOD,
    [PgName("AVERAGE")]
    AVERAGE,
    [PgName("BAD")]
    BAD,
    [PgName("VERY_BAD")]
    VERY_BAD
}