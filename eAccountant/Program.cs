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
        var invoice = context.Set<Invoice>().FirstOrDefault(i =>
            i.IssuerTaxId == "0000000001"
            && i.ReceiverTaxId == "0000000002"
            && i.Number == "FV/2026/01"
        );
        if (invoice == null)
        {
            context.Set<Invoice>().Add(new Invoice
            {
                IssuerTaxId = "0000000001",
                ReceiverTaxId = "0000000002",
                Number = "FV/2026/01",
                Price = 150,
                Pit = 0.12f,
                Vat = 0.23f,
            });
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
