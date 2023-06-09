using Api.Gateway.Proxies;
using Api.Gateway.Proxies.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<ApiUrls>(
    opts => builder.Configuration.GetSection("ApiUrls").Bind(opts)
    );

builder.Services.AddHttpClient<IProductProxy, ProductProxy>();

builder.Services.AddHttpClient<ISaleProxy, SaleProxy>();



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
