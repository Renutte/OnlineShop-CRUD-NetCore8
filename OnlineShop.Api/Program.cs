using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Api.Repositories;
using OnlineShop.Api.Services;
using AutoMapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios en el contenedor
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true; 
    options.JsonSerializerOptions.PropertyNamingPolicy = null; 
});

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopConnection")));

// Registrar repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreProductRepository, StoreProductRepository>();

// Registrar servicios
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IStoreProductService, StoreProductService>();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
