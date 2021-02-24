using System;
using System.Collections.Generic;
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
    }
}
