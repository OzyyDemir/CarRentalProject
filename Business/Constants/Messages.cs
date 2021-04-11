using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Bakımda";
        public static string CarsListed = "Listelendi";
        public static string CarDeleted="Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string BrandAdded="Marka eklendi";
        public static string BrandDeleted="Marka silindi";
        public static string BrandUpdated="Marka güncellendi";
        public static string CarImageAdded="Araba Resmi eklendi";
        public static string FailedCarImageAdd = "Resim yüklenirken hata oluştu";
        public static string AuthorizationDenied="Yetkilendirme hatası";
        public static string CarImagesCountExceded="Sınır Aşımı";
        public static string succeed = "başarılı";
        public static string listed = "listelendi";
        
        public static string TokenCreated = "Token oluşturuldu";


        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string WrongPassword = "Hatalı parola";

        public static string SuccessfulLogin = "Başarılı giriş";
        public static string Registered = "Kaydedildi";
        public static string UserAvailable = "Kullanıcı uygun";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string CarImageCarIdInvalid = "Resim nesnesinin id si geçersiz";
    }
}
