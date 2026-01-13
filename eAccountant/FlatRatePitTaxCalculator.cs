namespace eAccountant;

class FlatRatePitTaxCalculator : ITaxCalculator
{
    protected float _tax = 0;
    public float Tax { get => _tax; }
    public string Name { get => "Flat rate PIT"; }
    public void ProcessInvoice(Database.Invoice invoice, bool isCost)
    {
        if (invoice.Pit == null || isCost) return;
        var price = invoice.Price;
        if (invoice.Vat != null) {
            price -= price * invoice.Vat.Value;
        }
        _tax += price * invoice.Pit.Value;
    }
}