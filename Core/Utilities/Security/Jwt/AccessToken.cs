using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
   public class AccessToken //erişim anahtarı
    {
        public string Token { get; set; }//jsonwebtoken değerimiz 
        public DateTime Expiration { get; set; } //verilen tokenın ne zaman sonlanacagı
    }
}
