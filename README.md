# OrderIntegration

OrderIntegration, farklý mimari yaklaþýmlarla geliþtirilmiþ iki ayrý yönetim sistemini entegre etmeyi amaçlayan bir projedir. Bu çözümde, modern mikro servis mimarisi ile geleneksel n-katmanlý mimari bir arada kullanýlmýþtýr.

## A Þirketi Sistemi (Mikro Servis Mimarisi)

A Þirketi'nin sipariþ yönetim sistemi, ölçeklenebilirlik ve esneklik saðlamak amacýyla mikro servis mimarisi üzerine inþa edilmiþtir. Bu sistemdeki OrderManager Serviste, Onion Architecture, CQRS (Command Query Responsibility Segregation) ve Domain-Driven Design (DDD) prensipleri uygulanmýþtýr.

**Temel Bileþenler:**

* **OrderIntegration.ACompany.Services.OrderManager.API:** Sistemin dýþ dünya ile iletiþimini saðlayan API katmanýdýr.
* **OrderIntegration.ACompany.Services.OrderManager.Application:** Uygulama katmaný, iþ mantýðýný ve kullaným senaryolarýný (use case'leri) içerir.
* **OrderIntegration.ACompany.Services.OrderManager.Domain:** Ýþ kurallarýný ve domain modellerini barýndýran domain katmanýdýr.
* **OrderIntegration.ACompany.Services.OrderManager.Infrastructure:** Veritabaný eriþimi, mesajlaþma gibi altyapýsal bileþenleri içerir.
* **OrderIntegration.ACompany.Services.OrderManager.Worker:** Asenkron görevleri ve arka plan iþlemlerini gerçekleþtiren worker servisidir.

* **OrderIntegration.ACompany.Web** WebUI arayüzüdür.
* **OrderIntegration.ACompany.Gateways.WebGateway** Mikro servis mimarisi için bir API Gateway saðlar. Ocelot kütüphanesi kullanýlarak geliþtirilmiþtir.
* **OrderIntegration.ACompany.IdentityServer** Mikro servis mimarisi için olan kimlik ve eriþim yönetim sunucusu. (Henüz çalýþýr durumda deðil)
* **OrderIntegration.ACompany.Shared** Ortak kullaným gerektiren sýnýflarý bulundurur.

## B Þirketi Sistemi (Monolitik Mimari)

B Þirketi'nin sipariþ yönetim sistemi, klasik n-katmanlý mimari ile monolitik bir yapýya sahiptir. Bu sistem, daha basit bir yapý sunarken, mikro servis mimarisine kýyasla daha az esneklik saðlayabilir.

**Temel Bileþenler:**

* **OrderIntegration.BCompany.API:** Sistemin dýþ dünya ile iletiþimini saðlayan API katmanýdýr.
* **OrderIntegration.BCompany.Business:** Ýþ mantýðýný içeren katmandýr.
* **OrderIntegration.BCompany.DataAccess:** Veritabaný eriþimini saðlayan katmandýr.
* **OrderIntegration.BCompany.Entities:** Veritabaný tablolarýný temsil eden entity (varlýk) sýnýflarýný içerir.

## Entegrasyon (Worker Service)

A Þirketi ve B Þirketi sistemleri arasýndaki entegrasyon, A Þirketi sistemindeki worker service aracýlýðýyla gerçekleþtirilir. Worker service, B Þirketi sistemine REST ve SOAP istekleri göndererek veri alýþveriþini saðlar.

## Çalýþtýrma ve Geliþtirme

1. Projeyi klonlayýn: `git clone https://github.com/ozberkesn/OrderIntegration.git`
2. Gerekli baðýmlýlýklarý yükleyin (`dotnet restore`)
3. Veritabanlarýný yapýlandýrýn ve gerekli baðlantý bilgilerini ayarlayýn.
4. Uygulamalarý çalýþtýrýn.
(`dotnet run --project OrderIntegration.ACompany.Gateways.WebGateway &`)
(`dotnet run --project OrderIntegration.ACompany.Services.OrderManager.Worker &`)
(`dotnet run --project OrderIntegration.ACompany.Services.OrderManager.API &`)
(`dotnet run --project OrderIntegration.ACompany.Web &`)
(`dotnet run --project OrderIntegration.ACompany.IdentityServer &`)
(`dotnet run --project OrderIntegration.BCompany.API &`)

