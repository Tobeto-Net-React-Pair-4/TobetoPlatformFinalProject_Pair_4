using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class BusinessMessages
    {
        public static string CategoryLimit = "Kategori sayısı 10 adetten fazla olamaz";
        public static string CategoryCourseLimit = "Bir kategoride 20 adetten fazla kurs olamaz";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string LoginError = "Giriş hatalı";
        public static string UserExists = "Kullanıcı kayıtlı";

    }
}
