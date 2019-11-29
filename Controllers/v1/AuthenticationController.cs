using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StringR.Backend.DAO;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public static readonly string SecretKey = "yeTAdHIcM2IBFWBjRRPDCD4Ro5uLMlXiu67OyNkQUyI4VkEoUrAk0qE01XJNRL87bVyWjXmjYyTWRli1u1R2xHUMpoPHMkEOj5ehTw5RjQgcZDHzjIKf735UUqyNqNYJ7UOzuwVi1m6lXFwOMGQdVTgAIxSF3NhQ2fzGSegLWf8NeqFNbrdKK9LfMfTWPy2UWUabmjRkRwIymJ1lEZwXuXxp8yHt7LOl3y2RuW9Prmsu25Nf4rQupXqvVL9gB0fPeiB4smbGUSVuDHYRaHDn4KV1UjYvkBOifz6pVARH00WsKFTdBg3KfaMqwUK8PwVjmNpfRgY7r5dRafuqiwAxJ732XB9b4cLyh3EUntKt2NglDObAs8VZG73Oi6U15IJuAaOSNuE1Q7YVq6vpkawXILx90N1ytRlBXVL5vFtJPHfKLdlLt2P2gh0RKsFPTxXchaMNj6TanrTFdxyqnmQ3iZkHYOBa61XGeObddtoz2yatn10V7iEf23k5QTCcROEV";
        private int DaysValid = 360;
        private string Issuer = "https://prostringr.com";
        private string Audience = "https://prostringr.com";
        
        private IShopDataController _shopDataController;
        
        public AuthenticationController(IConfiguration configuration)
        {
            _shopDataController = new ShopDataController(new ShopDAO(configuration));
        }
        
        [HttpPost]
        public ActionResult<string> ShopLogin([FromBody] UserForAcces login)
        {

            // control the user input
            if (login.userName == null || login.password == null)
            {
                return BadRequest("Invalid input");
            }
            
            // check if the user exits in the DB
            var response = _shopDataController.ValidateShop(login.userName, login.password);
            
            // check the result from searching the DB
            if (response == 1) 
            {
                // if we have a user then create a token for the user
                var token = CreateToken(login.userName);
                return Ok(token);
            }
            
            // if dont have a user return a badrequest
            return NotFound("We could not find a shop corresponding the username and password");
        }

        private string CreateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
            
            var token = tokenHandler.CreateJwtSecurityToken(issuer: Issuer, audience: Audience, subject: claimsIdentity,
                notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddDays(DaysValid), signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.Default.GetBytes(SecretKey)),
                    SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

    }
}