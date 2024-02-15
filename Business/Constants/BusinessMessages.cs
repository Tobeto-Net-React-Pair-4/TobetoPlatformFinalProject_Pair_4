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
        public static string CourseNameAlreadyExists = "Bu kurs adında zaten bir kurs bulunmaktadır";
        public static string AuthorizationDenied = "Gerekli yetkiye sahip değilsiniz";
        public static string LoginPasswordError = "Şifrenizi kontrol ediniz";
        public static string LoginSuccess = "Giriş başarılı";
        public static string PasswordNull = "Parola boş olmamalı";
        public static string UserExists = "Kullanıcı kayıtlı";
        public static string UserNotExists = "Kullanıcı kayıtlı değil";
        public static string SameCategoryName = "Aynı isimde bir kategori bulunamaz";


    }
}
