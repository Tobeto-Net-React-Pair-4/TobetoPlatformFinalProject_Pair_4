using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {/*Kullanıcının yolladığı requestten sonra eğer doğruysa çalışacak
        Doğruysa veritabanına gidip o kullanıcının claimlerini bulacak, jwt üretip clienta geri dönecek.*/
        AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims);
    }
}
