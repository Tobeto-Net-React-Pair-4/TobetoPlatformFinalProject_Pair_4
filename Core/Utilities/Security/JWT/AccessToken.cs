using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {//Kullanıcı istek yaparken yetki gerektiren bir şeyse elindeki tokenı da ekleyip yollanmasına yardımcı olur
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
