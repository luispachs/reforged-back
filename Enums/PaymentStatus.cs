namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum PaymentStatus {
    [PgName("PENDING")]
    PENDING,
    [PgName("PAID")]
    PAID,
    [PgName("REFUNDED")]
    REFUNDED
}