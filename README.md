📦 Katmanlar ve Sorumlulukları
1. Entities
Veritabanı tablolarına karşılık gelen sınıfları içerir.

Work.cs: To-Do görev modelini temsil eder.

BaseEntity.cs: Tüm entity’lerin miras aldığı ortak alanları (Id, CreatedDate vs.) içerir.

2. DataAccess
Veritabanı işlemleri (CRUD) burada yapılır.

Yapılar:

Contexts: EF Core için DbContext sınıfı.

Repositories: Generic repository yapısı ve özel repository implementasyonları.

Interfaces: Repository arayüzleri.

Configurations: Fluent API konfigürasyonları.

UnitOfWork: Tüm repository'leri yönetir.

3. Business
İş kuralları ve servisler bu katmanda yer alır.

IWorkService gibi arayüzler ve servis implementasyonları bulunur.

ValidationRules: FluentValidation ile model doğrulamaları yapılır.

AutoMapper: DTO ve entity dönüşümleri için kullanılır.

Dependency: IoC container konfigürasyonları yer alır.

4. Dtos
Veri transfer nesneleri (DTO) burada yer alır.

Amaç: UI ile Business katmanı arasında sade ve güvenli veri alışverişi sağlamak.

5. UI (Kullanıcı Arayüzü)
ASP.NET Core MVC ile hazırlanmıştır.

View’lar (Razor) ve Controller’lar buradadır.

Bootstrap ile şık bir arayüz sağlanır.

Sayfalar: Görev listesi, görev ekleme, düzenleme, silme, 404 vs.

🔧 Teknolojiler:
ASP.NET Core 6.0

Entity Framework Core

AutoMapper

FluentValidation

Bootstrap

Katmanlı Mimari (NTier)

Repository Pattern + Unit of Work

✅ Öne Çıkan Özellikler:
Görev yönetimi (To-Do list)

CRUD işlemleri

Katmanlı mimari yapısı

Doğrulama kuralları

DTO kullanımı

Modern ve responsive kullanıcı arayüzü
