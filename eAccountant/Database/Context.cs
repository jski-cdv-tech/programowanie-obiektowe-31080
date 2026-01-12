using Microsoft.EntityFrameworkCore;

namespace eAccountant.Database;

class Context : DbContext
{
    public Context(DbContextOptions<Context> options): base(options) {}
    public DbSet<Invoice> Invoices { get; set; }
}