using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using Service.Mapping;
using Service.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Servisleri DI konteynerine ekleyin
builder.Services.AddScoped<IGenericRepository<Core.Models.Product>, GenericRepository<Core.Models.Product>>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, Service.Services.ProductService>();

builder.Services.AddScoped<IGenericRepository<Core.Models.Category>, GenericRepository<Core.Models.Category>>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, Service.Services.CategoryService>();

builder.Services.AddScoped<IGenericRepository<Core.Models.Supplier>, GenericRepository<Core.Models.Supplier>>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, Service.Services.SupplierService>();

builder.Services.AddScoped<IGenericRepository<Core.Models.Customer>, GenericRepository<Core.Models.Customer>>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, Service.Services.CustomerService>();

builder.Services.AddScoped<IGenericRepository<Core.Models.Shipper>, GenericRepository<Core.Models.Shipper>>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IShipperService, Service.Services.ShipperService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity eklenmesi
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService<Core.Models.Product>, Service.Services.ProductService>();
builder.Services.AddScoped<IService<Core.Models.Category>, Service.Services.CategoryService>();
builder.Services.AddScoped<IService<Core.Models.Supplier>, Service.Services.SupplierService>();
builder.Services.AddScoped<IService<Core.Models.Customer>, Service.Services.CustomerService>();
builder.Services.AddScoped<IService<Core.Models.Shipper>, Service.Services.ShipperService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Bu sat�r public dosyalar� servis eder
app.UseRouting();

app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();