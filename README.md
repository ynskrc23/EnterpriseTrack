# Enterprise Track App

## Mimari Yapı ve Kullanılan Teknolojiler:

### Katmanlı Mimari:
#### Core Katmanı: İş kurallarını ve genel model tanımlarını içerir. Bu katmanda, IGenericRepository, IService, IProductRepository gibi arayüzlerin yer aldığı görülüyor.
#### Repository Katmanı: Veritabanı işlemlerini gerçekleştiren GenericRepository ve özelleşmiş repository sınıfları (ProductRepository, CategoryRepository vb.) yer alıyor.
#### Service Katmanı: İş kurallarını yöneten, repository'ler ile iş birliği yapan servisler (ProductService, CategoryService vb.) bulunuyor.
#### Unit of Work: Veritabanı işlemlerinin tek bir iş birimi olarak yönetilmesi için UnitOfWork sınıfı kullanılmış.

### Dependency Injection (DI):
#### Servislerin ve repository'lerin bağımlılık enjeksiyonu (DI) kullanılarak Scoped ömrüyle yönetildiği görülüyor. Bu, her istek için yeni bir örneğin oluşturulup, istek tamamlandığında temizlenmesini sağlar.

### Entity Framework Core:
#### Veritabanı işlemleri için kullanılan bir ORM'dir. Npgsql paketi ile PostgreSQL veritabanı destekleniyor.

### Identity Framework:
#### Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için ASP.NET Core Identity entegre edilmiş.
##### AppUser ve AppRole gibi özelleşmiş kullanıcı ve rol modelleri tanımlanmış.

### AutoMapper:
#### Veri transferi sırasında model ve DTO (Data Transfer Object) dönüşümlerini kolaylaştırmak için MapProfile kullanılmış.

### Swagger (OpenAPI):
#### API'nin dökümantasyonu için Swagger desteği eklenmiş.

### CORS Politikası:
#### CORS (Cross-Origin Resource Sharing) politikası sayesinde API'nin herhangi bir kaynaktan gelen talepleri kabul ettiği belirtilmiş.

### Cors, Routing ve Middleware Kullanımı:
#### UseCors, UseAuthentication, UseAuthorization gibi ASP.NET Core middleware'leri yapılandırılmış.
#### HTTPS yönlendirme ve statik dosya servis etme özellikleri eklenmiş.


# Projenin Swagger Dökümanı Fotoğrafları

### Categories API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/categories.PNG)

### Customers API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/customers.PNG)

### Employees API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/employees.PNG)

### Orders API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/orders.PNG)

### Products API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/products.PNG)

### Regions API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/regions.PNG)

### Shippers API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/shippers.PNG)

### Suppliers API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/suppliers.PNG)

### Territories API
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/territories.PNG)

### DB Shcemas
![](https://github.com/ynskrc23/EnterpriseTrack/blob/master/image/db.PNG)