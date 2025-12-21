namespace Lab4;

public abstract class Vehicle
{
    public int Id { get; set; }
    public double EngineCapacity { get; protected set; }
    public int Year { get; protected set; }
    public string Model { get; protected set; }

    public Vehicle(double engineCapacity, string model, int year)
    {
        EngineCapacity = engineCapacity;
        Model = model;
        Year = year;
    }

    public void Update(double newEngineCapacity, string newModel, int newYear)
    {
        EngineCapacity = newEngineCapacity;
        Model = newModel;
        Year = newYear;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public void ShowMe()
    {
        Console.WriteLine($"Model: {Model}, Year: {Year}");
    }

    public void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }

    public abstract void Test();
}