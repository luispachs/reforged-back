namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum DpncSolution {
    [PgName("REJECTED")]
    REJECTED,
    [PgName("REPROCESSED")]
    REPROCESSED,
    [PgName("RECLASIFICATED")]
    RECLASIFICATED,
    [PgName("REPROCESSES_PROVIDER")]
    REPROCESSES_PROVIDER,
    [PgName("RECYCLED")]
    RECYCLED,
    [PgName("HAND_TO_HAND")]
    HAND_TO_HAND
}