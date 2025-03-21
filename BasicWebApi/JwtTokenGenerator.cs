using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicWebApi
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {
            //JwtSecurityTokenHandler=> bunun obyektden write metodunu cagirib Security tokeni parametr kimi veririk.
            SymmetricSecurityKey key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12345671234567123456712345671234567."));

            SigningCredentials credentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Member"));
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",claims:null,audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }
    }
}
