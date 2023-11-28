using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        //public object UserModel { get; set; }

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
       // [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModelRepositry login)
        {
            
            IActionResult _unauthorizeduser = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                string tokenString = GenerateJSONWebToken((UserModelRepositry)user);
                var response = Ok(new { token = tokenString });
                return response;
            }

            return _unauthorizeduser;
        }

        //private object AuthenticateUser(UserModelRepositry login)
        //{
        //    throw new NotImplementedException();
        //}

        //private object AuthenticateUser(UserModelRepositry login)
        //{
        //throw new NotImplementedException();
        //}

        //public string GenerateJSONWebToken(UserModelRepositry user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //     null,
        //    expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //       return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
            
            private UserModelRepositry AuthenticateUser(UserModelRepositry login)
            {
                UserModelRepositry user = null;

                //Validate the User Credentials    
                //Demo Purpose, I have Passed HardCoded User Information    
                if (login.UserName == "shalini")
                {
                    user = new UserModelRepositry { UserName = "Shalinikumari", UserEmail = "shalini.kumari@successive.tech" };
                }
                return user;
            }
            private string GenerateJSONWebToken(UserModelRepositry userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.UserEmail),
        //new Claim("DateOfJoing", userInfo.DateOfJoing("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Typ, Guid.NewGuid().ToString())
               };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }



    

