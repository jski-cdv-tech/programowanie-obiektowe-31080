namespace eAccountant;

public interface ITaxCalculator
{
    float Tax { get; }
    string Name { get; }
    void ProcessInvoice(Database.Invoice invoice, bool isCost);
}