using MediatR;
using Microsoft.EntityFrameworkCore;
using Sale.Persistance.Database;
using Sale.Service.Proxies;
using Sale.Service.Proxies.Product;
using Sale.Service.Proxies.Product.Interfaces;
using Sale.Service.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(
        connectionString,
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Sale")
        )
);

builder.Services.Configure<ApiUrls>(
    opts => builder.Configuration.GetSection("ApiUrls").Bind(opts)
    );

builder.Services.AddHttpClient<IProductProxy, ProductProxy>();

builder.Services.AddMediatR(Assembly.Load("Sale.Service.EventHandlers"));

builder.Services.AddTransient<ISaleQueryService, SaleQueryService>();



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
