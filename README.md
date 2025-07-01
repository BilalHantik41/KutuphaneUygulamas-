# Kutuphane Uygulaması

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş basit bir kütüphane yönetim uygulamasıdır. Yazarlar ve kitaplar için CRUD (Oluşturma, Okuma, Güncelleme, Silme) işlemlerini destekler ve verileri bellek içi (in-memory) bir veri deposunda saklar.

## Özellikler

* Yazarlar için:

  * Listeleme
  * Yeni yazar ekleme
  * Yazar bilgilerini güncelleme
  * Yazar silme
* Kitaplar için:

  * Listeleme
  * Yeni kitap ekleme
  * Kitap bilgilerini güncelleme
  * Kitap silme
  * Kitapları yazar bilgisiyle görüntüleme

## Teknolojiler

* .NET 6.0 veya üzeri
* ASP.NET Core MVC
* C#
* Razor View Engine
* In-Memory Veri Deposu

## Gereksinimler

* .NET SDK 6.0 veya üzeri ([https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download))
* Tercihen Visual Studio 2022 veya Visual Studio Code

## Kurulum

1. Depoyu klonlayın veya indirin:

   ```bash
   git clone https://github.com/kullanici/KutuphaneUygulaması.git
   ```
2. Proje klasörüne gidin:

   ```bash
   cd KutuphaneUygulaması/KutuphaneUygulaması
   ```
3. Bağımlılıkları yükleyin ve projeyi derleyin:

   ```bash
   dotnet restore
   dotnet build
   ```
4. Uygulamayı çalıştırın:

   ```bash
   dotnet run
   ```
5. Tarayıcınızda `https://localhost:5001` adresine giderek uygulamayı kullanabilirsiniz.

## Proje Yapısı

```
/KutuphaneUygulaması
│
├─ Controllers      # MVC kontrolcüler
│  ├─ AuthorsController.cs
│  ├─ BooksController.cs
│  └─ HomeController.cs
│
├─ Models           # Veri modelleri
│  ├─ Author.cs
│  └─ Book.cs
│
├─ Data             # In-memory veri deposu
│  └─ InMemoryDataStore.cs
│
├─ Views            # Razor görünümleri
│  ├─ Authors
│  ├─ Books
│  ├─ Home
│  └─ Shared
│
├─ wwwroot          # Statik dosyalar (CSS, JS, img)
│
├─ appsettings.json # Uygulama ayarları
├─ Program.cs       # Uygulama başlangıç konfigürasyonu
└─ KutuphaneUygulaması.csproj
```

## Kullanım

* **Anasayfa:** Projenin kök dizinine yönlendirilir.
* **Yazarlar:** `/Authors` yolundan yazarları listeleyebilir, yeni yazar ekleyebilir, düzenleyebilir veya silebilirsiniz.
* **Kitaplar:** `/Books` yolundan kitapları listeleyebilir, yeni kitap ekleyebilir, düzenleyebilir veya silebilirsiniz.

## Katkıda Bulunma

Katkılarınız memnuniyetle karşılanır! Lütfen bir konu oluşturun (issue) veya çekme isteği (pull request) gönderin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakabilirsiniz.
