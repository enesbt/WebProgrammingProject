# Hayvan Barınağı Sistemi
## Proje Amacı
- Kullanıcılara barınaktaki hayvanları sahiplendirmek ve kullanıcıların barınağa hayvan bırakmasını sağlamak
## Veritabanı
- AnimalGives
- AnimalHouses
- AnimalRequests
- AnimalTypes
- Animals
- AspNetRoles
- AspNetUserRoles
- AspNetUsers
![Ekran görüntüsü 2023-07-15 183018](https://github.com/enesbt/WebProgrammingProject/assets/95939881/e296c2c4-cb94-49be-ba0e-a4afe119fb65)
## Kullanıcılar
-Admin
-Member
-Standart
## Kullanıcı Yetkileri
#### Admin
- Kullanıcı hayvan sahiplenme işlemleri onaylar veya onaylamaz
- Kullanıcı hayvan barınağına teslim işlemini onaylar veya onaylamaz
- Yeni barınak ekleyebilir
- Hayvan Türleri ekleyebilir
- Barınak hayvanlarının ilanlanlarını kullanıcı sayfasına ekler
- Türkçe ve İngilizce olarak sayfayı görüntüleyebilir
#### Member
- Barınaktaki hayvanlara sahiplenme isteği gönderebilir
- Barınağa hayvan bırakma isteği gönderebilir
- Her üye kendine ait isteklerinin onaylanıp onaylanmadığını görüntüleyebilir
- Barınaktaki hayvanları görüntüleyebilir
- Kendisi ile ilgili bilgileri profil sayfasında görüntüleyebilir
 - Türkçe ve İngilizce olarak sayfayı görüntüleyebilir
#### Standart
- Anasayfaya ulaşabilir
- İlanları görüntüleyemez
- Kayıt olabilir
- Kayıt olursa üye yetkisine sahip olur
- Türkçe ve İngilizce olarak sayfayı görüntüleyebilir
- AnimalRequests tablosuna ve Animal tablosuna api isteğinde bulunabilir

## Projede Kullanılan Teknolojiler
- Veritabanı tasarımı Code First yaklaşımı ile yapılmıştır.
- Framework olarak Entity Framework Core kullanılmıştır
- Proje geliştirme mimarisi olarak Çok Katmanlı Mimari kullanılmıştır.
- Kullanıcı , rol , yetki işlemleri için Identitiy kütüphanesi kullanılmıştır.
- Geliştirme yaklaşımı olarak Repository Design Pattern kullanılmıştır.
- Asp .Net Core 6.0
- Veritabanı PostgreSql

