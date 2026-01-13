namespace eAccountant;

class VatTaxCalculator : ITaxCalculator
{
    protected float _tax = 0;
    public float Tax { get => _tax; }
    public string Name { get => "VAT"; }
    public void ProcessInvoice(Database.Invoice invoice, bool isCost)
    {
        if (invoice.Vat == null) return;
        if (isCost) {
            _tax -= invoice.Price * invoice.Vat.Value;
        } else {
            _tax += invoice.Price * invoice.Vat.Value;
        }
    }
}