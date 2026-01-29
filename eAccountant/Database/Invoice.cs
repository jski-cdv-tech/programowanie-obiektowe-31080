using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace eAccountant.Database;

public class Invoice
{
    [Key]
    public int Id { get; init; }
    public required string IssuerTaxId { get; set; }
    public required string ReceiverTaxId { get; set; }
    public required string Number { get; set; }
    public required float Price { get; set; }
    // PIT makes sense only in income invoices
    public float? Pit { get; set; }
    // Can be skipped, if contractor isn't a registered VAT payer
    public float? Vat { get; set; }
}