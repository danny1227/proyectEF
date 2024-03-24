using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectef;

var builder = WebApplication.CreateBuilder(args);

//Asociamos el conexto a uno de base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>("Data source= DESKTOP-O0FRJBC\\SQLEXPRESSDEV;Initial Catalog=TareasDB;user id=sa; password=123456");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "  + dbContext.Database.IsInMemory());   
});

app.Run();
