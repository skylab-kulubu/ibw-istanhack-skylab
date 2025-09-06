# NFT Sertifikalı Online Kurs Platformu

Bu proje, kullanıcıların çeşitli kurslara kaydolup tamamladıklarında benzersiz NFT (Non-Fungible Token) olarak üretilmiş sertifikalar kazanabilecekleri bir web platformudur. Projenin amacı, sertifikaların dijital olarak doğrulanabilir, taklit edilemez ve tamamen kullanıcıya ait olmasını sağlamaktır.

## Proje Hakkında

Platform, modern web teknolojileri kullanılarak geliştirilmiştir. Backend tarafında C# ve .NET ile güçlü ve ölçeklenebilir bir API altyapısı hedeflenirken, frontend tarafında Vite ve React.js ile hızlı ve dinamik bir kullanıcı arayüzü sunulmaktadır.

## Kullanılan Teknolojiler

### Backend
- **Dil:** C#
- **Framework:** ASP.NET Core
- **Veritabanı:** MS SQL Server
- **ORM:** Entity Framework Core

### Frontend
- **Framework:** React.js
- **Build Aracı:** Vite
- **Paket Yöneticisi:** npm / yarn
- **Stil:** Tailwind CSS

## Özellikler (Planlanan)

- **Kullanıcı Yönetimi:** Kayıt olma, giriş yapma ve profil yönetimi.
- **Kurs Kataloğu:** Mevcut tüm kursların listelenmesi ve detaylarının görüntülenmesi.
- **Kurs Kaydı:** Kullanıcıların ilgilendikleri kurslara kaydolabilmesi.
- **Sertifika Kazanımı:** Kursları başarıyla tamamlayan kullanıcılara özel sertifika oluşturulması.
- **NFT Entegrasyonu:** Oluşturulan her sertifikanın bir NFT olarak blockchain ağına kaydedilmesi ve benzersiz hale getirilmesi.
- **Profilim Sayfası:** Kullanıcıların kaydoldukları kursları ve kazandıkları NFT sertifikalarını görüntüleyebilmesi.

## Projenin Mevcut Durumu

Bu proje aktif olarak geliştirme aşamasındadır. Güncel durumu aşağıda özetlenmiştir:

- **Backend (C# & .NET):** API endpoint'leri ve temel iş mantığı geliştirilmektedir. Veritabanı şeması oluşturulmuştur ve servisler kendi içinde çalışır durumdadır.
- **Frontend (Vite + React.js):** Kullanıcı arayüzü bileşenleri ve sayfa tasarımları geliştirilmektedir. Arayüz, şu anda statik veya sahte (mock) verilerle çalışmaktadır.

> **⚠️ ÖNEMLİ NOT:**
> - **Bağlantı Eksikliği:** Backend ve Frontend arasında henüz bir API entegrasyonu yapılmamıştır. İki katman da birbirinden bağımsız olarak geliştirilmektedir.
> - **NFT Entegrasyonu:** NFT teknolojisi henüz projeye entegre edilmemiştir. Bu özellik, geliştirme yol haritasının ilerleyen aşamalarında eklenecektir.

## Kurulum

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyebilirsiniz.

### Ön Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download) veya üzeri
- [Node.js](https://nodejs.org/en/) (LTS versiyonu tavsiye edilir)
- Bir kod editörü (örn: Visual Studio Code, Visual Studio)
- Git

### Backend Kurulumu

1. Projeyi klonlayın:
   ```sh
   git clone https://github.com/skylab-kulubu/ibw-istanhack-skylab.git
   ```

2. Backend klasörüne gidin:

3. Gerekli paketleri yükleyin:
   ```sh
   dotnet restore
   ```

4. Projeyi klonlayın:
   ```sh
   dotnet ef database update
   ```

5. Projeyi klonlayın:
   ```sh
   dotnet run
   ```
   
### Frontend Kurulumu

1. Frontend klasörüne gidin:

2. Gerekli paketleri yükleyin:
   ```sh
   npm install
   ```

4. Projeyi çalıştırın:
   ```sh
   npm run dev
   ```

## Uygulama Görselleri

### Ana Sayfa
![anasayfa](https://github.com/skylab-kulubu/ibw-istanhack-skylab/blob/main/anasayfa.png)

### Kurslar
![kurslar](https://github.com/skylab-kulubu/ibw-istanhack-skylab/blob/main/kurslar.png)

### Ekip
![anasayfa](https://github.com/skylab-kulubu/ibw-istanhack-skylab/blob/main/ekip.png)
