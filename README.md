# E-Commerce Proje
*Asp.Net Core kullanılarak ve çok katmanlı bir mimari ile geliştirilmiştir.

*'Code First' yaklaşımı kullanıldı.

*Farklı türdeki nesneleri birbirine dönüştürmek için 'AutoMapper' kütüphanesi kullanıldı.

*Hataları tek bir yerden yönetebileceğimiz bir yapı kuruldu.(WebAPI/Extensions/ExceptionMiddlewareExtensions)

*WebAPI Projesi sadece konfigürasyonları içerir ve Controller'lar Presentation katmanındadır.

*Validation işlemi 'FluentValidation' kullanılarak yapılmıştır.

*Query string'den alınan parametrelere göre sayfalama yapılabilir durumdadır.

*Filtreleme, arama ve sıralama işlemleri yapıldı.

*In-Memory Cache yapılanması kuruldu.

## Kullanılan Pattern'ler
-Generic Repository Pattern

  Kod tekrarını önlemek ve yönetilebilirliği artırmak için kullanılan bir pattern'dir. Projemizde herbir model için 
  ortak olan metotları tekrar tekrar uygulamak yerine ortak bir yapı oluşturulur. İşte bu yapı Generic Repositry Pattern'dir.

-Unit Of Work

  Veritabanıyla ilgili her değişikliğin anlık olarak veritabanına yansıtılması yerine toplu bir şekilde yansıtılmasını sağlar.                                        
