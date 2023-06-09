using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Persistance.Database;
using Product.Service.Queries;
using Product.Service.Queries.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(
        connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Product")
        )
);

builder.Services.AddMediatR(Assembly.Load("Product.Service.EventHandlers"));

builder.Services.AddTransient<IProductQueryService, ProductQueryService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
