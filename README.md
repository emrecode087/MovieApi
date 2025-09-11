# MovieApi Project

Bu proje, film verilerini y�netmek i�in geli�tirilmi� bir ASP.NET Core Web API ve Razor Pages uygulamas�d�r. Clean Architecture prensiplerine uygun olarak CQRS ve Mediator Design Pattern'lerini kullanarak geli�tirilmi�tir.

## ?? Proje �zellikleri

- **Clean Architecture** yap�s� ile geli�tirilmi�
- **CQRS (Command Query Responsibility Segregation)** pattern implementasyonu
- **Mediator Design Pattern** kullan�m�
- **Entity Framework Core** ile PostgreSQL veritaban� entegrasyonu
- **ASP.NET Core Web API** ile RESTful servisler
- **Razor Pages** ile web aray�z�
- **Swagger/OpenAPI** dok�mantasyonu
- **.NET 9** framework deste�i

## ??? Proje Mimarisi

Proje Clean Architecture prensiplerine uygun olarak a�a��daki katmanlarda organize edilmi�tir:

```
MovieApi/
??? Core/
?   ??? MovieApi.Domain/          # Domain entities ve business rules
?   ??? MovieApi.Application/     # Application services, CQRS handlers, ve business logic
??? Infrastructure/
?   ??? MovieApi.Persistence/     # Data access layer ve Entity Framework implementasyonlar�
??? Presentation/
?   ??? MovieApi.WebApi/         # Web API controllers ve endpoints
??? Frontends/
    ??? MovieApi.WebUI/          # Razor Pages web aray�z�
```

### Domain Entities

- **Movie**: Film bilgilerini tutar (ba�l�k, a��klama, rating, s�re, ��k�� tarihi)
- **Category**: Film kategorilerini y�netir
- **Cast**: Oyuncu/akt�r bilgilerini saklar
- **Tag**: Film etiketlerini tutar
- **Review**: Kullan�c� yorumlar�n� ve de�erlendirmelerini saklar

## ??? Teknolojiler

- **.NET 9**
- **ASP.NET Core Web API**
- **ASP.NET Core Razor Pages**
- **Entity Framework Core**
- **PostgreSQL**
- **MediatR** (Mediator pattern i�in)
- **Swagger/OpenAPI**

## ?? Gereksinimler

- .NET 9 SDK
- PostgreSQL veritaban�
- Visual Studio 2022 veya Visual Studio Code

## ?? Kurulum

1. **Repository'yi klonlay�n:**
```bash
git clone <repository-url>
cd MovieApi
```

2. **PostgreSQL veritaban�n� ayarlay�n:**
   - PostgreSQL'in y�kl� oldu�undan emin olun
   - `MovieDb` ad�nda bir veritaban� olu�turun
   - Connection string'i `Infrastructure/MovieApi.Persistence/Context/MovieContext.cs` dosyas�nda g�ncelleyin

3. **NuGet paketlerini y�kleyin:**
```bash
dotnet restore
```

4. **Veritaban� migration'lar�n� uygulay�n:**
```bash
dotnet ef database update --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

5. **Web API'yi �al��t�r�n:**
```bash
cd Presentation/MovieApi.WebApi
dotnet run
```

6. **Web UI'yi �al��t�r�n (ayr� bir terminal'de):**
```bash
cd Frontends/MovieApi.WebUI
dotnet run
```

## ?? API Endpoints

### Movies
- `GET /api/movies` - T�m filmleri getir
- `GET /api/movies/GetMovie?id={id}` - ID'ye g�re film getir
- `POST /api/movies` - Yeni film olu�tur
- `PUT /api/movies` - Film g�ncelle
- `DELETE /api/movies/{id}` - Film sil

### Categories
- `GET /api/categories` - T�m kategorileri getir
- `GET /api/categories/GetCategory?id={id}` - ID'ye g�re kategori getir
- `POST /api/categories` - Yeni kategori olu�tur
- `PUT /api/categories` - Kategori g�ncelle
- `DELETE /api/categories/{id}` - Kategori sil

### Tags
- `GET /api/tags` - T�m etiketleri getir
- `GET /api/tags/GetTagById?id={id}` - ID'ye g�re etiket getir
- `POST /api/tags` - Yeni etiket olu�tur
- `PUT /api/tags` - Etiket g�ncelle
- `DELETE /api/tags?id={id}` - Etiket sil

### Casts
- `GET /api/casts` - T�m oyuncular� getir
- `GET /api/casts/GetCastById?id={id}` - ID'ye g�re oyuncu getir
- `POST /api/casts` - Yeni oyuncu olu�tur
- `PUT /api/casts` - Oyuncu g�ncelle
- `DELETE /api/casts?id={id}` - Oyuncu sil

## ?? API Dok�mantasyonu

Proje �al��t�r�ld�ktan sonra Swagger UI'ye �u adresten eri�ebilirsiniz:
```
https://localhost:{port}/swagger
```

## ??? Design Patterns

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Veri de�i�tirme i�lemleri (Create, Update, Delete)
- **Queries**: Veri okuma i�lemleri (Get, List)

### Mediator Pattern
- Tag ve Cast operasyonlar� i�in MediatR kullan�lm��t�r
- Movie ve Category operasyonlar� i�in manuel handler implementasyonu

## ??? Proje Yap�s�

### Core Layer
- **Domain**: Entity'ler ve domain logic
- **Application**: Use case'ler, CQRS handlers, ve application services

### Infrastructure Layer
- **Persistence**: Entity Framework context ve veritaban� konfig�rasyonlar�

### Presentation Layer
- **WebApi**: REST API endpoints
- **WebUI**: Razor Pages kullan�c� aray�z�

## ?? Geli�tirme

### Yeni Entity Ekleme
1. `Core/MovieApi.Domain/Entities/` klas�r�nde yeni entity olu�turun
2. `MovieContext.cs` dosyas�na DbSet ekleyin
3. Migration olu�turup uygulay�n
4. CQRS handlers ve commands/queries olu�turun
5. Controller ekleyin

### Migration Olu�turma
```bash
dotnet ef migrations add MigrationName --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

## ?? Katk�da Bulunma

1. Fork edin
2. Feature branch olu�turun (`git checkout -b feature/amazing-feature`)
3. De�i�ikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request olu�turun

## ?? Lisans

Bu proje MIT lisans� alt�nda lisanslanm��t�r.

## ?? �leti�im

Proje hakk�nda sorular�n�z i�in issue olu�turabilirsiniz.

---

**Not:** Veritaban� connection string'ini production ortam�nda environment variable'lar veya configuration dosyalar� �zerinden y�netmeyi unutmay�n.