using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private string secretKey = "yeTAdHIcM2IBFWBjRRPDCD4Ro5uLMlXiu67OyNkQUyI4VkEoUrAk0qE01XJNRL87bVyWjXmjYyTWRli1u1R2xHUMpoPHMkEOj5ehTw5RjQgcZDHzjIKf735UUqyNqNYJ7UOzuwVi1m6lXFwOMGQdVTgAIxSF3NhQ2fzGSegLWf8NeqFNbrdKK9LfMfTWPy2UWUabmjRkRwIymJ1lEZwXuXxp8yHt7LOl3y2RuW9Prmsu25Nf4rQupXqvVL9gB0fPeiB4smbGUSVuDHYRaHDn4KV1UjYvkBOifz6pVARH00WsKFTdBg3KfaMqwUK8PwVjmNpfRgY7r5dRafuqiwAxJ732XB9b4cLyh3EUntKt2NglDObAs8VZG73Oi6U15IJuAaOSNuE1Q7YVq6vpkawXILx90N1ytRlBXVL5vFtJPHfKLdlLt2P2gh0RKsFPTxXchaMNj6TanrTFdxyqnmQ3iZkHYOBa61XGeObddtoz2yatn10V7iEf23k5QTCcROEV";
        private int daysValid = 1;
        private string authority = "https://prostringr.com";      
        
        [HttpGet]
        public ActionResult<string> shopLogin()
        {

            // control the user input
//            if (userName == null || password != null)
//            {
//                return BadRequest("Invalid input");
//            }
            
            // check if the user exits in the DB
            
            
            // check the result from searching the DB
            
            // if dont have a user return a badrequest
            
            // if we have a user then create a token for the user
            var token = CreateToken("Marcus"); 
            
            
            // return the user with the repsonse from the look up, the tokenString and the userName
            return token;
        }

        private string CreateToken(string userName)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
            
            var token = tokenHandler.CreateJwtSecurityToken(issuer: authority, audience: authority, subject: claimsIdentity,
                notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddSeconds(daysValid), signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

    }
}