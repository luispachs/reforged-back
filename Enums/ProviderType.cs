namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum ProviderType
{
    [PgName("INTERNAL")]

    INTERNAL = 0,

    [PgName("PROVIDER")]
    PROVIDER = 1
}
