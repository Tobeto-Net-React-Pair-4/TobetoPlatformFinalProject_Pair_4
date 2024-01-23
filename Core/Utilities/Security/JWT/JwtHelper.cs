using Core.Entities.Abstract;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //webapi kısnındaki appsettings.jsonu okumamıza yarıyor
        public IConfiguration Configuration { get; }
        //appsettings.jsondaki değerleri tokenoptions nesnesine atıyoruz. 
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //appsetting içindeki token options bölümünü alıyor ve <TokenOptions> sınıfındaki değerlerle maple
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        //kullanıcı için tokenı ürettiğimiz yer
        public AccessToken CreateToken(IUser user, List<IOperationClaim> operationClaims)
        {
            //token süresi ne zaman bitecek
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //token oluştururken güvenlik anahtarına ihtiyacımız var.SecurityKeyHelperdan alıyoruz.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //hangi anahtarı ve algoritmayı kullnacağı bilgisi
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //jwt'yi oluşturuyoruz
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        //jwt security token oluşturuyor
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, IUser user,
            SigningCredentials signingCredentials, List<IOperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //kullanıcının claimlerini alıp liste oluşturuyor.
        //extensions içinden alıyoruz
        private IEnumerable<Claim> SetClaims(IUser user, List<IOperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
