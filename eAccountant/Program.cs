using eAccountant.Components;
using eAccountant.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<eAccountant.Database.Context>(options =>
{
    var path = System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eAccountant");
    options.UseSqlite($"Data Source={path}.db");
    options.UseSeeding((context, _) =>
    {
        var invoices = new List<Invoice>
        {
            new() {
                IssuerTaxId = "0000000001",
                ReceiverTaxId = "0000000002",
                Number = "FV/2025/10",
                Price = 150,
                Pit = 0.12f,
                Vat = 0.23f,
            },
            new() {
                IssuerTaxId = "0000000003",
                ReceiverTaxId = "0000000001",
                Number = "2025/9",
                Price = 160,
            },
        };
        foreach (var invoice in invoices)
        {
            if (null == context.Set<Invoice>().FirstOrDefault(i =>
                i.IssuerTaxId == invoice.IssuerTaxId
                && i.ReceiverTaxId == invoice.ReceiverTaxId
                && i.Number == invoice.Number))
            {
                context.Set<Invoice>().Add(invoice);
            }
        }
        var settings = new List<Setting>
        {
            new() { Name = "TaxId", Value = "0000000001" },
            new() { Name = "IsRegisteredVatPayer", Value = "1" },
            new() { Name = "PitMethod", Value = "Progressive" },
        };
        foreach (var setting in settings)
        {
            if (null == context.Set<Setting>().FirstOrDefault(i => i.Name == setting.Name))
            {
                context.Set<Setting>().Add(setting);
            }
        }
        context.SaveChanges();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
