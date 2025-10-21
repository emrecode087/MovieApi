# MovieApi Project

Bu proje, film verilerini yönetmek için geliştirilmiş bir **ASP.NET Core Web API** ve **Razor Pages** uygulamasıdır. Clean Architecture prensiplerine uygun olarak **CQRS** ve **Mediator Design Pattern** kullanılarak geliştirilmiştir.

## 🚀 Proje Özellikleri

* **Clean Architecture** yapısı ile geliştirilmiş
* **CQRS (Command Query Responsibility Segregation)** pattern implementasyonu
* **Mediator Design Pattern** kullanımı
* **Entity Framework Core** ile PostgreSQL veritabanı entegrasyonu
* **ASP.NET Core Web API** ile RESTful servisler
* **Razor Pages** ile web arayüzü
* **Swagger/OpenAPI** dokümantasyonu
* **.NET 9** framework desteği

## 🏛️ Proje Mimarisi

Proje, Clean Architecture prensiplerine uygun olarak aşağıdaki katmanlarda organize edilmiştir:

```
MovieApi/
├── Core/
│   ├── MovieApi.Domain/        # Domain entities ve business rules
│   └── MovieApi.Application/   # Application services, CQRS handlers ve business logic
├── Infrastructure/
│   └── MovieApi.Persistence/   # Data access layer ve EF Core implementasyonları
├── Presentation/
│   └── MovieApi.WebApi/        # Web API controllers ve endpoints
└── Frontends/
    └── MovieApi.WebUI/         # Razor Pages web arayüzü
```

### Domain Entities

* **Movie**: Film bilgilerini tutar (başlık, açıklama, rating, süre, çıkış tarihi)
* **Category**: Film kategorilerini yönetir
* **Cast**: Oyuncu/aktör bilgilerini saklar
* **Tag**: Film etiketlerini tutar
* **Review**: Kullanıcı yorumlarını ve değerlendirmelerini saklar

## 🛠️ Kullanılan Teknolojiler

* **.NET 9**
* **ASP.NET Core Web API**
* **ASP.NET Core Razor Pages**
* **Entity Framework Core**
* **PostgreSQL**
* **MediatR** (Mediator pattern için)
* **Swagger/OpenAPI**

## 📦 Gereksinimler

* .NET 9 SDK
* PostgreSQL veritabanı
* Visual Studio 2022 veya Visual Studio Code

## ⚙️ Kurulum

1. **Repository'yi klonlayın:**

```bash
git clone <repository-url>
cd MovieApi
```

2. **PostgreSQL veritabanını ayarlayın:**

   * PostgreSQL'in yüklü olduğundan emin olun
   * `MovieDb` adında bir veritabanı oluşturun
   * Connection string'i `Infrastructure/MovieApi.Persistence/Context/MovieContext.cs` dosyasında güncelleyin

3. **NuGet paketlerini yükleyin:**

```bash
dotnet restore
```

4. **Veritabanı migration'larını uygulayın:**

```bash
dotnet ef database update --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

5. **Web API'yi çalıştırın:**

```bash
cd Presentation/MovieApi.WebApi
dotnet run
```

6. **Web UI'yi çalıştırın (ayrı bir terminal'de):**

```bash
cd Frontends/MovieApi.WebUI
dotnet run
```

## 🔗 API Endpoints

### Movies

* `GET /api/movies` → Tüm filmleri getir
* `GET /api/movies/GetMovie?id={id}` → ID'ye göre film getir
* `POST /api/movies` → Yeni film oluştur
* `PUT /api/movies` → Film güncelle
* `DELETE /api/movies/{id}` → Film sil

### Categories

* `GET /api/categories` → Tüm kategorileri getir
* `GET /api/categories/GetCategory?id={id}` → ID'ye göre kategori getir
* `POST /api/categories` → Yeni kategori oluştur
* `PUT /api/categories` → Kategori güncelle
* `DELETE /api/categories/{id}` → Kategori sil

### Tags

* `GET /api/tags` → Tüm etiketleri getir
* `GET /api/tags/GetTagById?id={id}` → ID'ye göre etiket getir
* `POST /api/tags` → Yeni etiket oluştur
* `PUT /api/tags` → Etiket güncelle
* `DELETE /api/tags?id={id}` → Etiket sil

### Casts

* `GET /api/casts` → Tüm oyuncuları getir
* `GET /api/casts/GetCastById?id={id}` → ID'ye göre oyuncu getir
* `POST /api/casts` → Yeni oyuncu oluştur
* `PUT /api/casts` → Oyuncu güncelle
* `DELETE /api/casts?id={id}` → Oyuncu sil

## 📖 API Dokümantasyonu

Proje çalıştırıldıktan sonra Swagger UI'ye şu adresten erişebilirsiniz:

```
https://localhost:{port}/swagger
```

## 🧩 Design Patterns

### CQRS (Command Query Responsibility Segregation)

* **Commands** → Veri değiştirme işlemleri (Create, Update, Delete)
* **Queries** → Veri okuma işlemleri (Get, List)

### Mediator Pattern

* **Tag** ve **Cast** operasyonları için **MediatR** kullanılmıştır
* **Movie** ve **Category** operasyonları için manuel handler implementasyonu yapılmıştır

## 📂 Proje Yapısı

### Core Layer

* **Domain**: Entity'ler ve domain logic
* **Application**: Use case'ler, CQRS handlers ve application services

### Infrastructure Layer

* **Persistence**: EF Core context ve veritabanı konfigürasyonları

### Presentation Layer

* **WebApi**: REST API endpoints
* **WebUI**: Razor Pages kullanıcı arayüzü

## 👨‍💻 Geliştirme

### Yeni Entity Ekleme

1. `Core/MovieApi.Domain/Entities/` klasöründe yeni entity oluşturun
2. `MovieContext.cs` dosyasına DbSet ekleyin
3. Migration oluşturup uygulayın
4. CQRS handlers ve commands/queries ekleyin
5. Controller ekleyin

### Migration Oluşturma

```bash
dotnet ef migrations add MigrationName --project Infrastructure/MovieApi.Persistence --startup-project Presentation/MovieApi.WebApi
```

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## 📜 Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır.

## 📬 İletişim

Proje hakkında sorularınız için issue oluşturabilirsiniz.

---

**Not:** Production ortamında connection string'i environment variable veya configuration dosyaları üzerinden yönetmeyi unutmayın.
