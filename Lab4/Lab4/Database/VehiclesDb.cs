using Lab4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Lab4.Database;

public class VehiclesDb : DbContext
{
    public string DbPath { get; }
    public VehiclesDb()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "vehicles.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Bike> Bikes { get; set; }

    public List<Vehicle> Vehicles
    {
        get
        {
            var list = new List<Vehicle>();
            list.AddRange(Bikes.ToList());
            list.AddRange(Cars.ToList());
            return list;
        }
    }
}