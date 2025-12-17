namespace Lab3;

public class Bike : Vehicle
{
    public Bike(double engineCapacity, string model, int year) : base(engineCapacity, model, year)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Bike started");
    }

    public override void Test()
    {
        Console.WriteLine("Bike test");
    }
}