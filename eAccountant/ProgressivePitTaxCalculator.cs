using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eAccountant;

class ProgressivePitTaxCalculator : ITaxCalculator
{
    protected float _gross_cost = 0;
    protected float _gross_income = 0;
    public float Tax
    {
        get {
            var gross = Math.Max(0, _gross_income - 3600) - _gross_cost;
            var tax = 0f;
            if (gross > 120_000) {
                tax += (gross - 120_000) * 0.32f;
                gross = 120_000;
            }
            tax += gross * 0.12f;
            return tax;
        }
    }
    public string Name { get => "Progressive PIT"; }
    public void ProcessInvoice(Database.Invoice invoice, bool isCost)
    {
        var price = invoice.Price;
        if (invoice.Vat != null) {
            price -= price * invoice.Vat.Value;
        }
        if (isCost) {
            _gross_cost += price;
        } else {
            _gross_income += price;
        }
    }
}