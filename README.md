## Bu Depoya Neler Dahil?

Aşağıdaki özellikleri **Eventim** üzerinden uyguladık.

#### Aşağıdakileri içeren katalog mikroservisi;

- ASP.NET Çekirdek Web API uygulaması
- REST API ilkeleri, CRUD işlemleri
- **MongoDB veritabanı** bağlantısı ve konteynerleştirme
- Repository Pattern Uygulaması
- Swagger Open API uygulaması

#### Aşağıdakileri içeren basket mikroservisi;

- ASP.NET Web API uygulaması
- REST API ilkeleri, CRUD işlemleri
- **Redis veritabanı** bağlantısı ve konteynerleştirme
- Ürünün nihai fiyatını hesaplamak üzere servisler arası senkronizasyon iletişimi için İndirim **Grpc servisi** kullanın
- **MassTransit ve RabbitMQ** kullanarak BasketCheckout Sırasını yayınlayın

#### Mikrosevis İletişimi

- Servisler arası senkronizasyon **gRPC İletişimi**
- **RabbitMQ Message-Broker Servisi** ile Eşzamansız Mikroservis İletişimi
- **RabbitMQ Yayınlama/Abone Olma Konusu** Değişim Modelini Kullanma
- RabbitMQ Message-Broker sistemi üzerinden soyutlama için **MassTransit** kullanma
- BasketCheckout olay kuyruğunu Basket mikroservislerinden yayınlama ve bu olaya Sipariş verme mikroservislerinden abone
  olma
- **RabbitMQ EventBus.Messages kitaplığı** oluşturun ve Microservices referanslarını ekleyin

#### Mikroservis Siparişi Verme

- En İyi Uygulamaları kullanarak **DDD, CQRS ve Temiz Mimariyi** uygulama
- MediatR, FluentValidation ve AutoMapper paketlerini kullanarak **CQRS geliştirme**
- **MassTransit-RabbitMQ** Yapılandırması kullanılarak **RabbitMQ** BasketCheckout olay sırası kullanılıyor
- **SqlServer veritabanı** bağlantısı ve konteynerleştirme
- **Entity Framework Core ORM** kullanımı ve uygulama başlatıldığında SqlServer'a otomatik geçiş

#### API Gateway Ocelot Mikroservisi

- **Ocelot ile API Gateway** uygulayın
- API Gateway aracılığıyla yeniden yönlendirilecek örnek mikroservisler/kapsayıcılar
- Birden çok farklı **API Gateway/BFF** kapsayıcı türü çalıştırın
- Shopping.Aggregator'daki Gateway toplama modeli

#### WebUI ShoppingApp Mikroservisi

- Bootstrap 4 ve Razor şablonlu ASP.NET Core Web Uygulaması
- **HttpClientFactory** ve **Polly** ile \*\*Ocelot API'lerini arayın

#### Mikroservisler Kesişen Uygulamalar

- Uygulama **Elastik Yığın (ELK) ile Merkezi Dağıtılmış Günlük Kaydı; Mikroservisler için Elasticsearch, Logstash,
  Kibana ve SeriLog**
- Back-end ASP.NET mikroservislerinde **HealthChecks** özelliğini kullanın
- Servisler genelinde durumu ve yükü izleyebilen ve HealthChecks ile sorgulayarak mikroservisler hakkında sağlık raporu
  verebilen ayrı bir serviste **Watchdog** kullanma

#### Mikroservis Dayanıklılığı Uygulamaları

- Mikroservisleri daha dayanıklı hale getirme Esnek HTTP isteklerini uygulamak için **IHttpClientFactory** kullanın
- IHttpClientFactory ve **Polly ilkeleri** ile üstel geri alma ile **Yeniden Dene ve Devre Kesici modellerini**
  uygulayın

#### Yardımcı Konteynerler

- Farklı Docker ortamlarınızı kolayca yönetmenize olanak tanıyan Container hafif yönetim kullanıcı arabirimi için *
  *Portainer**'ı kullanın
- **pgAdmin PostgreSQL Araçları** PostgreSQL için zengin özelliklere sahip Açık Kaynak yönetim ve geliştirme platformu

#### Docker üzerinde tüm mikroservisler ile Docker Compose kurulumu;

- Mikroservislerin konteynerleştirilmesi
- Veritabanlarının konteynerleştirilmesi
- Ortam değişkenlerini geçersiz kıl

## Projeyi Çalıştır

Aşağıdaki araçlara ihtiyacınız olacak:

- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
- [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Yükleme

Geliştirme ortamınızı ayarlamak için şu adımları izleyin: (Docker Masaüstünü Çalıştırmadan Önce)

1. Depoyu klonlayın
2. Windows için Docker yüklendikten sonra, minimum bellek ve CPU miktarını şu şekilde yapılandırmak için sistem
   tepsisindeki Docker simgesinden **Ayarlar > Gelişmiş seçeneğine** gidin:

- **Memory: 4 GB**
- CPU: 2 3.**docker-compose.yml** dosyalarını içeren kök dizinde aşağıdaki komutu çalıştırın:

```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

4. Docker'ın tüm mikroservislerini oluşturmasını bekleyin.(bazı mikroservislerin çalışması için fazladan zamana ihtiyaç
   vardır, bu nedenle ilk kapatmada çalışmazsa lütfen bekleyin)

5. Aşağıdaki url'lerde **mikroservisleri** başlatabilirsiniz:

- **Catalog API -> http://localhost:8000/swagger/index.html**
- **Car API -> http://localhost:3000/swagger/index.html**
- **Book API -> http://localhost:3001/swagger/index.html**
- **Basket API -> http://localhost:8001/swagger/index.html**
- **Ordering API -> http://localhost:8004/swagger/index.html**
- **Aggregator -> http://localhost:8005/swagger/index.html**
- **API Gateway -> http://localhost:8010/Catalog**
- **Rabbit Management Dashboard -> http://localhost:15672**  guest/guest
- **pgAdmin PostgreSQL -> http://localhost:5050** -- admin@egeuniversity.com/admin
    - Kullanıcı adı: admin@egeuniversity.com
    - Şifre: admin
- **Elasticsearch -> http://localhost:9200**
- **Kibana -> http://localhost:5601**
- **Web Status -> http://localhost:8007**

5. Web Durumunu görüntülemek için tarayıcınızda http://host.docker.internal:8007'yi başlatın. Her mikro hizmetin
   sağlıklı olduğundan emin olun.
