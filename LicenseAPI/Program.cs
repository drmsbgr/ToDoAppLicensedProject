using LicenseAPI;
using LicenseLib;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(o =>
{
    o.UseSqlite("Data Source = license.db");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/createlic", (string machineId, RepositoryContext context) =>
{
    if (context.Licenses.AsNoTracking().Any(x => x.MachineID == machineId))
        return Results.BadRequest("Bu cihaz için daha önce lisans üretilmiş!");

    return Results.Ok(LicenseManager.GenerateLicenseKey(machineId));
})
.WithName("Create License");

app.MapGet("api/validatelic", (string machineId, string key, RepositoryContext context) =>
{
    if (!LicenseManager.IsLicenseKeyValid(key))
        return Results.BadRequest("Girdiğiniz lisans geçersiz!");

    var found = context.Licenses.AsNoTracking().FirstOrDefault(x => x.LicenseKey == key);

    if (found is not null)
    {
        if (found.MachineID != machineId)
            return Results.BadRequest("Bu lisans başka bir cihaz tarafından kullanılıyor!");
        else
            return Results.Ok("Ürün tekrar aktifleştirildi!");
    }
    else
    {
        context.Licenses.Add(new()
        {
            MachineID = machineId,
            LicenseKey = key
        });
    }

    context.SaveChanges();
    return Results.Ok();
})
.WithName("Validate License");

Console.WriteLine(LicenseManager.GetMachineId());

app.Run();
