namespace eAccountant;

class ProgressivePitTaxCalculator : ITaxCalculator
{
    protected float _gross = 0;
    public float Tax
    {
        get {
            var gross = _gross;
            var tax = 0f;
            if (gross > 120_000) {
                tax += (gross - 120_000) * 0.32f;
                gross = 120_000;
            }
            tax += gross * 0.12f - 3600;
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
            _gross -= price;
        } else {
            _gross += price;
        }
    }
}