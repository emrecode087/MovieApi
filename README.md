# MovieApi Project

Bu proje, film verilerini yönetmek için geliþtirilmiþ bir ASP.NET Core Web API ve Razor Pages uygulamasýdýr. Clean Architecture prensiplerine uygun olarak CQRS ve Mediator Design Pattern'lerini kullanarak geliþtirilmiþtir.

## ?? Proje Özellikleri

- **Clean Architecture** yapýsý ile geliþtirilmiþ
- **CQRS (Command Query Responsibility Segregation)** pattern implementasyonu
- **Mediator Design Pattern** kullanýmý
- **Entity Framework Core** ile PostgreSQL veritabaný entegrasyonu
- **ASP.NET Core Web API** ile RESTful servisler
- **Razor Pages** ile web arayüzü
- **Swagger/OpenAPI** dokümantasyonu
- **.NET 9** framework desteði

## ??? Proje Mimarisi

Proje Clean Architecture prensiplerine uygun olarak aþaðýdaki katmanlarda organize edilmiþtir:

```
MovieApi/
??? Core/
?   ??? MovieApi.Domain/          # Domain entities ve business rules
?   ??? MovieApi.Application/     # Application services, CQRS handlers, ve business logic
??? Infrastructure/
?   ??? MovieApi.Persistence/     # Data access layer ve Entity Framework implementasyonlarý
??? Presentation/
?   ??? MovieApi.WebApi/         # Web API controllers ve endpoints
??? Frontends/
    ??? MovieApi.WebUI/          # Razor Pages web arayüzü
```

### Domain Entities

- **Movie**: Film bilgilerini tutar (baþlýk, açýklama, rating, süre, çýkýþ tarihi)
- **Category**: Film kategorilerini yönetir
- **Cast**: Oyuncu/aktör bilgilerini saklar
- **Tag**: Film etiketlerini tutar
- **Review**: Kullanýcý yorumlarýný ve deðerlendirmelerini saklar

## ??? Teknolojiler

- **.NET 9**
- **ASP.NET Core Web API**
- **ASP.NET Core Razor Pages**
- **Entity Framework Core**
- **PostgreSQL**
- **MediatR** (Mediator pattern için)
- **Swagger/OpenAPI**

## ?? Gereksinimler

- .NET 9 SDK
- PostgreSQL veritabaný
- Visual Studio 2022 veya Visual Studio Code

## ?? Kurulum

1. **Repository'yi klonlayýn:**
```bash
git clone <repository-url>
cd MovieApi
```

2. **PostgreSQL veritabanýný ayarlayýn:**
   - PostgreSQL'in yüklü olduðundan emin olun
   - `MovieDb` adýnda bir veritabaný oluþturun
   - Connection string'i `Infrastructure/MovieApi.Persistence/Context/MovieContext.cs` dosyasýnda güncelleyin

3. **NuGet paketlerini yükleyin:**
```bash
dotnet restore
```

4. **Veritabaný migration'larýný uygulayýn:**
```bash
dotnet ef database update --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

5. **Web API'yi çalýþtýrýn:**
```bash
cd Presentation/MovieApi.WebApi
dotnet run
```

6. **Web UI'yi çalýþtýrýn (ayrý bir terminal'de):**
```bash
cd Frontends/MovieApi.WebUI
dotnet run
```

## ?? API Endpoints

### Movies
- `GET /api/movies` - Tüm filmleri getir
- `GET /api/movies/GetMovie?id={id}` - ID'ye göre film getir
- `POST /api/movies` - Yeni film oluþtur
- `PUT /api/movies` - Film güncelle
- `DELETE /api/movies/{id}` - Film sil

### Categories
- `GET /api/categories` - Tüm kategorileri getir
- `GET /api/categories/GetCategory?id={id}` - ID'ye göre kategori getir
- `POST /api/categories` - Yeni kategori oluþtur
- `PUT /api/categories` - Kategori güncelle
- `DELETE /api/categories/{id}` - Kategori sil

### Tags
- `GET /api/tags` - Tüm etiketleri getir
- `GET /api/tags/GetTagById?id={id}` - ID'ye göre etiket getir
- `POST /api/tags` - Yeni etiket oluþtur
- `PUT /api/tags` - Etiket güncelle
- `DELETE /api/tags?id={id}` - Etiket sil

### Casts
- `GET /api/casts` - Tüm oyuncularý getir
- `GET /api/casts/GetCastById?id={id}` - ID'ye göre oyuncu getir
- `POST /api/casts` - Yeni oyuncu oluþtur
- `PUT /api/casts` - Oyuncu güncelle
- `DELETE /api/casts?id={id}` - Oyuncu sil

## ?? API Dokümantasyonu

Proje çalýþtýrýldýktan sonra Swagger UI'ye þu adresten eriþebilirsiniz:
```
https://localhost:{port}/swagger
```

## ??? Design Patterns

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Veri deðiþtirme iþlemleri (Create, Update, Delete)
- **Queries**: Veri okuma iþlemleri (Get, List)

### Mediator Pattern
- Tag ve Cast operasyonlarý için MediatR kullanýlmýþtýr
- Movie ve Category operasyonlarý için manuel handler implementasyonu

## ??? Proje Yapýsý

### Core Layer
- **Domain**: Entity'ler ve domain logic
- **Application**: Use case'ler, CQRS handlers, ve application services

### Infrastructure Layer
- **Persistence**: Entity Framework context ve veritabaný konfigürasyonlarý

### Presentation Layer
- **WebApi**: REST API endpoints
- **WebUI**: Razor Pages kullanýcý arayüzü

## ?? Geliþtirme

### Yeni Entity Ekleme
1. `Core/MovieApi.Domain/Entities/` klasöründe yeni entity oluþturun
2. `MovieContext.cs` dosyasýna DbSet ekleyin
3. Migration oluþturup uygulayýn
4. CQRS handlers ve commands/queries oluþturun
5. Controller ekleyin

### Migration Oluþturma
```bash
dotnet ef migrations add MigrationName --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

## ?? Katkýda Bulunma

1. Fork edin
2. Feature branch oluþturun (`git checkout -b feature/amazing-feature`)
3. Deðiþikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluþturun

## ?? Lisans

Bu proje MIT lisansý altýnda lisanslanmýþtýr.

## ?? Ýletiþim

Proje hakkýnda sorularýnýz için issue oluþturabilirsiniz.

---

**Not:** Veritabaný connection string'ini production ortamýnda environment variable'lar veya configuration dosyalarý üzerinden yönetmeyi unutmayýn.