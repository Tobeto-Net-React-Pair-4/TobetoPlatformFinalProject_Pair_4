using Core.Entities;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims);
    }
}
