using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash //burada hash olusturuluyor
            (string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512()) //passwordun salt ve hash değerlerini oluşturuyor
            {
                passwordSalt = hmac.Key;//her kullanıcı için key oluşturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//passwordu byte çevirir
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //veritabanındaki passwordhash ile kullanıcının gönderdiği passwordun hash ı uyuyor mu kontrol eder.
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //bize kullandıgımız key i sordugu için passwordsaltı veriyoruz
            { 
                var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //hesaplanan hash passwordsalt kullanarak yapılıyo
                //hashler byte array oldugu için
                for (int i = 0; i <computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
