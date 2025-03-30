# JwtAuthDemo

## Proje Açıklaması
JwtAuthDemo, JWT (JSON Web Token) kimlik doğrulama ve yetkilendirme işlemlerini gerçekleştiren bir ASP.NET Core Web API projesidir. Kullanıcı kaydı, giriş yapma ve belirli rollere sahip kullanıcıların yetkilendirilmesi gibi temel özellikleri içermektedir.

## Teknolojiler
- ASP.NET Core 6
- Entity Framework Core
- Microsoft SQL Server
- JWT Authentication
- Dependency Injection (DI)

## Kurulum

### 1. Projeyi Klonlayın
```sh
git clone https://github.com/kullaniciadi/JwtAuthDemo.git
cd JwtAuthDemo
```

### 2. Veritabanı Bağlantısını Yapılandırın
`appsettings.json` dosyasındaki `ConnectionStrings` alanını kendi SQL Server bağlantınıza göre güncelleyin:
```json
"ConnectionStrings": {
  "default": "server=YOUR_SERVER; database=JwtAuthDemo; Trusted_Connection=true; TrustServerCertificate=true"
}
```

### 3. Bağımlılıkları Yükleyin
```sh
dotnet restore
```

### 4. Veritabanı Migration İşlemi
```sh
dotnet ef database update
```

### 5. Uygulamayı Çalıştırın
```sh
dotnet run
```

## Kullanım

### 1. Kullanıcı Kaydı
- Endpoint: `POST /api/auth/register`
- Body (JSON):
```json
{
  "email": "ugur@example.com",
  "password": "1996"
}
```

### 2. Kullanıcı Girişi
- Endpoint: `POST /api/auth/login`
- Body (JSON):
```json
{
  "email": "deneme@example.com",
  "password": "123456"
}
```
- Dönen JWT Token ile yetkilendirilmiş endpointlere erişebilirsiniz.

### 3. Yetkilendirme Gerektiren Endpoint
- Endpoint: `GET /api/auth`
- Header:
```http
Authorization: Bearer <JWT_TOKEN>
```
- Sadece `Admin` rolüne sahip kullanıcılar erişebilir.

## Proje Yapısı
```
JwtAuthDemo/
│── Controllers/
│   └── AuthController.cs  # Kullanıcı kaydı ve giriş işlemleri
│── Context/
│   └── IdentityDbContext.cs  # EF Core ile veritabanı bağlantısı
│── Entities/
│   └── UserEntity.cs  # Kullanıcı modeli
│── Dtos/
│   ├── AddUserDto.cs  # Kullanıcı ekleme DTO'su
│   ├── LoginUserDto.cs  # Giriş işlemi için DTO
│   └── UserInfoDto.cs  # Kullanıcı bilgileri DTO'su
│── Jwt/
│   ├── JwtDto.cs  # JWT verileri
│   └── JwtHelper.cs  # JWT oluşturma yardımcı sınıfı
│── Managers/
│   └── UserManager.cs  # Kullanıcı yönetimi
│── Services/
│   └── IUserService.cs  # Kullanıcı servisi arayüzü
│── appsettings.json  # Konfigürasyon dosyası (JWT ve DB bilgileri içerir)
│── Program.cs  # Uygulama giriş noktası ve servis konfigürasyonu
```

## Güvenlik Önlemleri
- Kullanıcı şifreleri düz metin olarak saklanmamalıdır. Bir `Hashing` yöntemi uygulanmalıdır.
- JWT süresi (`ExpireMinute`) kısa tutulmalı ve gerektiğinde yenilenmelidir.
- Hassas bilgileri çevresel değişkenlerden (`Environment Variables`) almak daha güvenlidir.

## Lisans
Bu proje MIT lisansı altındadır.

