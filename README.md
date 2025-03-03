# 🚀 **Enterprise Track**

**Enterprise Track**, kurumsal uygulamalar için modern, genişletilebilir ve verimli bir altyapı sunan bir projedir. 
Çok katmanlı mimari, kapsamlı CRUD operasyonları, kullanıcı yönetimi ve güçlü bir iş mantığı ile modern iş gereksinimlerini karşılamak için tasarlanmıştır.

---

## 📌 **Mimari Yapı ve Kullanılan Teknolojiler**

### 🏗 **Katmanlı Mimari**
- **Core Katmanı**: 
  - İş kurallarını ve genel model tanımlarını içerir. 
  - `IGenericRepository`, `IService`, `IProductRepository` gibi arayüzleri barındırır.

- **Repository Katmanı**:
  - Veritabanı işlemlerini gerçekleştiren **Generic Repository** ve özel repository sınıflarını içerir.
  - `ProductRepository`, `CategoryRepository`, `OrderRepository` gibi özelleşmiş repository'ler yer alır.

- **Service Katmanı**:
  - İş kurallarını yöneten ve repository'lerle iş birliği yapan servisleri barındırır.
  - `ProductService`, `CategoryService`, `OrderService` gibi servis sınıfları yer alır.

- **Unit of Work**:
  - Veritabanı işlemlerinin tek bir iş birimi olarak yönetilmesini sağlar.

### 🛠 **Kullanılan Teknolojiler**
- **ASP.NET Core 7**
- **Entity Framework Core** (PostgreSQL desteği ile)
- **ASP.NET Identity** (Kimlik doğrulama ve yetkilendirme için)
- **AutoMapper** (Model-DTO dönüşümleri için)
- **Swagger (OpenAPI)** (API dökümantasyonu için)
- **CORS Desteği** (Cross-Origin Resource Sharing)

---

## 📌 **Proje Yapılandırması**

### 🔧 **Dependency Injection (DI)**
- Servislerin ve repository'lerin **Scoped** olarak bağımlılık enjeksiyonu ile yönetildiği görülüyor.
- **Scoped**, her istek için yeni bir örneğin oluşturulmasını ve istek tamamlandığında temizlenmesini sağlar.

```csharp
// Service ve Repository bağımlılıkları ekleniyor
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
```

### 🔒 **Kimlik Doğrulama ve Yetkilendirme**
- **ASP.NET Identity** kullanılarak **AppUser** ve **AppRole** ile kimlik doğrulama işlemleri sağlanmaktadır.

```csharp
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
```

### 🌍 **CORS Politikası**
- API'nin herhangi bir kaynaktan gelen talepleri kabul edebilmesi için CORS politikası tanımlanmıştır.

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => 
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});
```

### 📄 **Swagger (OpenAPI) Desteği**
- Swagger entegrasyonu sayesinde API uç noktaları dökümante edilmiştir.

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

---

## 📌 **API Endpoint Görselleri**

### 🔹 **Categories API**
![Categories](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/categories.PNG)

### 🔹 **Customers API**
![Customers](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/customers.PNG)

### 🔹 **Employees API**
![Employees](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/employees.PNG)

### 🔹 **Orders API**
![Orders](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/orders.PNG)

### 🔹 **Products API**
![Products](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/products.PNG)

### 🔹 **Regions API**
![Regions](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/regions.PNG)

### 🔹 **Shippers API**
![Shippers](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/shippers.PNG)

### 🔹 **Suppliers API**
![Suppliers](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/suppliers.PNG)

### 🔹 **Territories API**
![Territories](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/territories.PNG)

### 🔹 **Veritabanı Şeması**
![DB Schema](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/db.PNG)

---

## 📌 **Kurulum & Kullanım**

### 💻 **Projeyi Çalıştırma**
1️⃣ **Gereksinimleri yükleyin:**
   - .NET Core SDK 7+
   - PostgreSQL (veritabanı için)
   - Visual Studio veya VS Code

2️⃣ **Bağımlılıkları yükleyin:**
   ```bash
   dotnet restore
   ```

3️⃣ **Veritabanını oluşturun:**
   ```bash
   dotnet ef database update
   ```

4️⃣ **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```

### 🛠 **Ortam Değişkenleri (.env)**
`.appsettings.json` içerisinde PostgreSQL bağlantı dizesini aşağıdaki gibi yapılandırabilirsiniz:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=EnterpriseTrackDB;Username=postgres;Password=yourpassword"
}
```

---

## 📌 **Geliştirme Süreci**
- 📌 **Repository Pattern** kullanılarak modüler ve sürdürülebilir bir yapı oluşturuldu.
- 📌 **Unit of Work Pattern** ile veritabanı işlemlerinde transaction yönetimi sağlandı.
- 📌 **DTO (Data Transfer Object)** kullanılarak veri güvenliği ve model dönüşümleri optimize edildi.
- 📌 **SOLID prensipleri** doğrultusunda geliştirme yapıldı.

---

## 🎯 **Katkıda Bulunma**
Projeye katkıda bulunmak isterseniz lütfen bir **pull request** açın veya **issue** oluşturun! 🙌

---

## 📌 **Lisans**
Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasına göz atabilirsiniz.

---

🚀 **Enterprise Track** ile kurumsal uygulamalarınızı en iyi şekilde yönetin! 🚀
