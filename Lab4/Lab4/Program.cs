using Lab4;
using Lab4.Database;
using Microsoft.EntityFrameworkCore;

var db = new VehiclesDb();
bool run = true;
do
{
    Console.WriteLine("CAR SHOP");
    Console.WriteLine(
        "[1] Show all, "
        + "[2] Search by year, "
        + "[3] Search by model, "
        + "[4] Search by engine capacity, "
        + "[5] Add vehicle, "
        + "[6] Remove vehicle, "
        + "[7] Edit vehicle, "
        + "[0] Exit"
    );
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    switch (input)
    {
        case '1':
            DisplayVehicleModel();
            break;
        case '2':
            SearchByYear();
            break;
        case '3':
            SearchByModel();
            break;
        case '4':
            SearchByEngineCapacity();
            break;
        case '5':
            AddNewVehicle();
            break;
        case '6':
            RemoveVehicle();
            break;
        case '7':
            EditVehicle();
            break;
        case '0':
            run = false;
            break;
        default:
            Console.WriteLine("Invalid menu option");
            break;
    }
}
while (run);
Console.WriteLine("Goodbye");

void DisplayVehicleModel()
{
    Console.WriteLine("Our vehicles:");
    Console.WriteLine();
    foreach (var vehicle in db.Vehicles)
    {
        if (vehicle is Car)
        {
            Console.Write("Car ");
        }
        else
        {
            Console.Write("Bike ");
        }
        Console.WriteLine($"{vehicle.Id}: {vehicle.Model}, {vehicle.Year}, {vehicle.EngineCapacity}");
    }
    Console.WriteLine();
}

void SearchByYear()
{
    Console.Write("Enter year: ");
    var success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        SearchByYear();
        return;
    }
    var vehicles = db.Vehicles.Where(vehicle => vehicle.Year == year);
    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}

void SearchByModel()
{
    Console.Write("Enter model: ");
    var model = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    else
    {
        model = model.ToLower();
    }
    var vehicles = db.Vehicles.Where(vehicle => vehicle.Model.ToLower() == model);
    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}

void SearchByEngineCapacity()
{
    Console.Write("Enter engine capacity: ");
    var success = Double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }
    var vehicles = db.Vehicles.Where(vehicle => vehicle.EngineCapacity == engineCapacity);
    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Model);
        }
    }
}

void AddNewVehicle()
{
    Console.WriteLine("B for bike, C for car");
    var input = Console.ReadKey().KeyChar.ToString().ToLower();
    if (input is not ("b" or "c"))
    {
        Console.WriteLine("Invalid vehicle type");
        return;
    }
    Console.WriteLine();
    Console.Write("Enter engine capacity: ");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }
    Console.Write("Enter model: ");
    string? model = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    Console.Write("Enter year: ");
    success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
    }
    Vehicle v;
    if (input == "c")
    {
        v = new Car(engineCapacity, model, year);
    }
    else
    {
        v = new Bike(engineCapacity, model, year);
    }
    db.Add(v);
    db.SaveChanges();
}

void RemoveVehicle()
{
    Console.WriteLine("B for bike, C for car");
    var input = Console.ReadKey().KeyChar.ToString().ToLower();
    if (input is not ("b" or "c"))
    {
        Console.WriteLine("Invalid vehicle type");
        return;
    }
    Console.WriteLine();
    Console.Write("Enter vehicle ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid vehicle ID");
        return;
    }
    Console.WriteLine();
    if (input == "b")
    {
        db.Bikes.Where(b => b.Id == id).ExecuteDelete();
    }
    else
    {
        db.Cars.Where(c => c.Id == id).ExecuteDelete();
    }
    db.SaveChanges();
}

void EditVehicle()
{
    Console.WriteLine("B for bike, C for car");
    var input = Console.ReadKey().KeyChar.ToString().ToLower();
    if (input is not ("b" or "c"))
    {
        Console.WriteLine("Invalid vehicle type");
        return;
    }
    Console.WriteLine();
    Console.Write("Enter vehicle ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid vehicle ID");
        return;
    }
    Console.WriteLine();
    if (input == "b" && !db.Bikes.Where(b => b.Id == id).Any())
    {
        Console.WriteLine($"Bike with ID {id} doesn't exist");
        return;
    }
    else if (input == "c" && !db.Cars.Where(b => b.Id == id).Any())
    {
        Console.WriteLine($"Car with ID {id} doesn't exist");
        return;
    }
    Console.Write("Enter new model name: ");
    string? model = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    Console.Write("Enter new engine capacity: ");
    if (!double.TryParse(Console.ReadLine(), out double engineCapacity))
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }
    Console.Write("Enter new production year: ");
    if (!int.TryParse(Console.ReadLine(), out int year))
    {
        Console.WriteLine("Invalid production year");
        return;
    }
    if (input == "c")
    {
        db.Cars.Where(c => c.Id == id).First().Update(engineCapacity, model, year);
    }
    else
    {
        db.Bikes.Where(c => c.Id == id).First().Update(engineCapacity, model, year);
    }
    db.SaveChanges();
}