using Microsoft.EntityFrameworkCore;

namespace eAccountant.Database;

[PrimaryKey(nameof(IssuerTaxId), nameof(ReceiverTaxId), nameof(Number))]
public class Invoice
{
    public required string IssuerTaxId { get; init; }
    public required string ReceiverTaxId { get; init; }
    public required string Number { get; init; }
    public required float Price { get; init; }
    // PIT makes sense only in income invoices
    public float? Pit { get; init; }
    // Can be skipped, if contractor isn't a registered VAT payer
    public float? Vat { get; init; }
}