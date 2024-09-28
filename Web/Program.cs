using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllersWithViews(); // Hem API hem de Razor View deste�i sa�lar
builder.Services.AddRazorPages(); // Razor Pages servislerini ekleyin

// Veritaban� ba�lant�s�n�n eklenmesi
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

var app = builder.Build();

// HTTP istek i�leme hatt�n�n yap�land�r�lmas�
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Geli�tirme ortam� i�in hata sayfas�
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Hata sayfas�
    app.UseHsts(); // HSTS
}

app.UseHttpsRedirection(); // HTTPS y�nlendirmesi
app.UseStaticFiles(); // Statik dosyalar� servis et

app.UseRouting(); // Y�nlendirme middleware'ini ekle
app.UseAuthentication(); // Kimlik do�rulama middleware'ini ekle
app.UseAuthorization(); // Yetkilendirme middleware'ini ekle

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Account}/{action=Login}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages(); // Razor Pages y�nlendirmesi
    endpoints.MapControllers(); // API Controller y�nlendirmesi
});

app.Run();
