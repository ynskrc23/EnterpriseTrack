using API.Filters;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using Service.Mapping;
using Service.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Servisleri DI konteynerine ekleyin
builder.Services.AddScoped<IGenericRepository<Core.Models.Product>, GenericRepository<Core.Models.Product>>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, Service.Services.ProductService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService<Core.Models.Product>, Service.Services.ProductService>();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
