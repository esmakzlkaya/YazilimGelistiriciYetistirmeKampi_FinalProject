using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    // static - newlenmez
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimden bir ürün zaten var";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkilendirme isteği reddedildi.";
        public static string TransactionSucceed="\nTransaction başarılı.\n";
        public static string UserRegistered = "\n Kullanıcı kayıt başarılı.\n";
        public static string UserNotFound = "\n Kullanıcı bulunamadı.\n";
        public static string PasswordError = "\n Şifre hatalı.\n";
        public static string SuccessfulLogin = "\nGiriş başarılı.\n";
        public static string UserAlreadyExists = "\nKullanıcı zaten var.\n";
        public static string AccessTokenCreated = "\nAccess Token başarılı.\n";
    }
}
