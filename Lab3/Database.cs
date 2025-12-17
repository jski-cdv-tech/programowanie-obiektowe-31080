namespace Lab3;

public class Database
{
    public static List<Vehicle> Vehicles { get; set; } = [
        new Bike(engineCapacity: 0.6, model: "Yamaha", year: 2025),
        new Bike(engineCapacity: 0.9, model: "Kawasaki", year: 2023),
        new Car(engineCapacity: 2.0, model: "VW", year: 2006),
        new Car(engineCapacity: 1.0, model: "Fiat", year: 2018),
    ];
}