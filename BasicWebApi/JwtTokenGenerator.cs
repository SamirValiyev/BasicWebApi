using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BasicWebApi
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {
            //JwtSecurityTokenHandler=> bunun obyektden write metodunu cagirib Security tokeni parametr kimi veririk.
            SymmetricSecurityKey key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Samirsamirsamir2."));

            SigningCredentials signingCredentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",claims:null,audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:signingCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }
    }
}
