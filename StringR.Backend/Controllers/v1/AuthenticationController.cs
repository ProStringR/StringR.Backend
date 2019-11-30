using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        public ActionResult<string> ShopLogin([FromBody] UserForAccess login)
        {

//            // control the user input
//            if (login.UserName == null || login.Password == null)
//            {
//                return BadRequest("Invalid input");
//            }
//            
//            // check if the user exits in the DB
//            var response = _shopDataController.ValidateShop(login.UserName, login.Password);
//            
//            // check the result from searching the DB
//            if (response != 1) 
//            {
//                // if dont have a user return a bad request
//                return NotFound("We could not find a shop corresponding the username and password");
//            }
//            
//            // if we have a user then create a token for the user
//            var token = CreateToken(login.UserName);

            var savedPassword = HashingPassword(login.Password);
            var compared = ComparePassword(savedPassword, "HejHej");

            var isSame = savedPassword.Equals(HashingPassword(login.Password));


            return Ok("Result: " + isSame);
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

        private string HashingPassword(string stringToBeHashed)
        {
            // generating the salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            
            var passwordHashed = new Rfc2898DeriveBytes(stringToBeHashed, salt, 10000);

            byte[] hash = passwordHashed.GetBytes(20);
            
            // 36 because we have 16 from the salt and 20 for the password
            byte[] hashBytes = new byte[36];
            
            // getting hash and salt into the right position
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            
            return Convert.ToBase64String(hashBytes);
        }

        private bool ComparePassword(string savedPassword, string inputPassword)
        {
            
            // get the saved password in byte[]
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            
            // generating salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            
            // hash the password
            var passwordHashed = new Rfc2898DeriveBytes(inputPassword, salt, 10000);
            byte[] hash = passwordHashed.GetBytes(20);
            
            
            // validating the passwords
            var isPasswordEqual = true;

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i+16] != hash[i])
                {
                    isPasswordEqual = false;
                    break;
                }
            }
            
            return isPasswordEqual;
        }
    }
}