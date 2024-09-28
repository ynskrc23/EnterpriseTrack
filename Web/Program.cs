using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllersWithViews(); // Hem API hem de Razor View desteði saðlar
builder.Services.AddRazorPages(); // Razor Pages servislerini ekleyin

// Veritabaný baðlantýsýnýn eklenmesi
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

// HTTP istek iþleme hattýnýn yapýlandýrýlmasý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Geliþtirme ortamý için hata sayfasý
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Hata sayfasý
    app.UseHsts(); // HSTS
}

app.UseHttpsRedirection(); // HTTPS yönlendirmesi
app.UseStaticFiles(); // Statik dosyalarý servis et

app.UseRouting(); // Yönlendirme middleware'ini ekle
app.UseAuthentication(); // Kimlik doðrulama middleware'ini ekle
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

    endpoints.MapRazorPages(); // Razor Pages yönlendirmesi
    endpoints.MapControllers(); // API Controller yönlendirmesi
});

app.Run();
