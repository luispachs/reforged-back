namespace nago_reforged_api.Enums;
using NpgsqlTypes;

public enum PaymentMethod {
    [PgName("CASH")]
    CASH,
    [PgName("CREDIT_CARD")]
    CREDIT_CARD,
    [PgName("DEBIT_CARD")]
    DEBIT_CARD,
    [PgName("TRANSFER")]
    TRANSFER,
    [PgName("OTHER")]
    OTHER
}