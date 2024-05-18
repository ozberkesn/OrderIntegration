# OrderIntegration

OrderIntegration, farkl� mimari yakla��mlarla geli�tirilmi� iki ayr� y�netim sistemini entegre etmeyi ama�layan bir projedir. Bu ��z�mde, modern mikro servis mimarisi ile geleneksel n-katmanl� mimari bir arada kullan�lm��t�r.

## A �irketi Sistemi (Mikro Servis Mimarisi)

A �irketi'nin sipari� y�netim sistemi, �l�eklenebilirlik ve esneklik sa�lamak amac�yla mikro servis mimarisi �zerine in�a edilmi�tir. Bu sistemdeki OrderManager Serviste, Onion Architecture, CQRS (Command Query Responsibility Segregation) ve Domain-Driven Design (DDD) prensipleri uygulanm��t�r.

**Temel Bile�enler:**

* **OrderIntegration.ACompany.Services.OrderManager.API:** Sistemin d�� d�nya ile ileti�imini sa�layan API katman�d�r.
* **OrderIntegration.ACompany.Services.OrderManager.Application:** Uygulama katman�, i� mant���n� ve kullan�m senaryolar�n� (use case'leri) i�erir.
* **OrderIntegration.ACompany.Services.OrderManager.Domain:** �� kurallar�n� ve domain modellerini bar�nd�ran domain katman�d�r.
* **OrderIntegration.ACompany.Services.OrderManager.Infrastructure:** Veritaban� eri�imi, mesajla�ma gibi altyap�sal bile�enleri i�erir.
* **OrderIntegration.ACompany.Services.OrderManager.Worker:** Asenkron g�revleri ve arka plan i�lemlerini ger�ekle�tiren worker servisidir.

* **OrderIntegration.ACompany.Web** WebUI aray�z�d�r.
* **OrderIntegration.ACompany.Gateways.WebGateway** Mikro servis mimarisi i�in bir API Gateway sa�lar. Ocelot k�t�phanesi kullan�larak geli�tirilmi�tir.
* **OrderIntegration.ACompany.IdentityServer** Mikro servis mimarisi i�in olan kimlik ve eri�im y�netim sunucusu. (Hen�z �al���r durumda de�il)
* **OrderIntegration.ACompany.Shared** Ortak kullan�m gerektiren s�n�flar� bulundurur.

## B �irketi Sistemi (Monolitik Mimari)

B �irketi'nin sipari� y�netim sistemi, klasik n-katmanl� mimari ile monolitik bir yap�ya sahiptir. Bu sistem, daha basit bir yap� sunarken, mikro servis mimarisine k�yasla daha az esneklik sa�layabilir.

**Temel Bile�enler:**

* **OrderIntegration.BCompany.API:** Sistemin d�� d�nya ile ileti�imini sa�layan API katman�d�r.
* **OrderIntegration.BCompany.Business:** �� mant���n� i�eren katmand�r.
* **OrderIntegration.BCompany.DataAccess:** Veritaban� eri�imini sa�layan katmand�r.
* **OrderIntegration.BCompany.Entities:** Veritaban� tablolar�n� temsil eden entity (varl�k) s�n�flar�n� i�erir.

## Entegrasyon (Worker Service)

A �irketi ve B �irketi sistemleri aras�ndaki entegrasyon, A �irketi sistemindeki worker service arac�l���yla ger�ekle�tirilir. Worker service, B �irketi sistemine REST ve SOAP istekleri g�ndererek veri al��veri�ini sa�lar.

## �al��t�rma ve Geli�tirme

1. Projeyi klonlay�n: `git clone https://github.com/ozberkesn/OrderIntegration.git`
2. Gerekli ba��ml�l�klar� y�kleyin (`dotnet restore`)
3. Veritabanlar�n� yap�land�r�n ve gerekli ba�lant� bilgilerini ayarlay�n.
4. Uygulamalar� �al��t�r�n.
(`dotnet run --project OrderIntegration.ACompany.Gateways.WebGateway &`)
(`dotnet run --project OrderIntegration.ACompany.Services.OrderManager.Worker &`)
(`dotnet run --project OrderIntegration.ACompany.Services.OrderManager.API &`)
(`dotnet run --project OrderIntegration.ACompany.Web &`)
(`dotnet run --project OrderIntegration.ACompany.IdentityServer &`)
(`dotnet run --project OrderIntegration.BCompany.API &`)

