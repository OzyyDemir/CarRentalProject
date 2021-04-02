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
    }
}
