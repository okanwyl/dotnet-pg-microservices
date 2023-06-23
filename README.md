## Projeyi Çalıştırmak / How to run?

Aşağıdaki araçlara ihtiyacınız olacak/You will need these:

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [.Net Core 7 or later](https://dotnet.microsoft.com/download/dotnet-core/7)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installation/Yükleme

1. Repoyu klonlayın/ Clone repo
- Minimum gereksinim/Minimum requirement: **Memory: 4 GB**
- Minimum CPU Core/Minimum CPU Çekirdeği: 2

```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

2. Biraz bekledikten sonra aşağıdaki url'lerde **mikroservisleri** başlatabilirsiniz:/ After waiting some time, you can access these urls:

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
