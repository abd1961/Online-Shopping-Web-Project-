using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectDB.Entities;
using projectDB.Services;
using projectDB.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.SignalR;

namespace projectDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration configuration;

        private readonly IUserService _userService;     
        public UserController(IConfiguration configuration, IUserService user)
        {
            _userService = user;
            this.configuration = configuration;
        }
        //add user(Register user)
        [HttpPost,Route("AddUser")]
        // [Authorize(Roles="admin")]
        public IActionResult AddUserC(User user)
        {
            try
            {
                if(user != null) 
                {
                    _userService.addUser(user);
                }
                return StatusCode(200,user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete,Route("RemoveUser")]
        [Authorize(Roles = "admin")]
        public IActionResult RemoveUserC(User user) 
        {
            try
            {
                if (user != null)
                {
                    _userService.removeUser(user);
                }
                return StatusCode(200, "Removed user");
            }
            catch (Exception)
            {

                throw;
            }
        }


        //getAllusers
        [HttpGet,Route("GetAllUsers")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsersC()
        {
            try
            {
                List<User> users = _userService.getAllUsers();
                if (users != null)
                    return StatusCode(200, users);
                else
                    return StatusCode(400,"no users found");

            }
            catch (Exception e)
            {

                return StatusCode(400,$"no users {e.Message}");
            }
        }

        //getuser
        [HttpGet,Route("GetUser/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUser(int id)
        {
            try
            {
                User user = _userService.GetUser(id);
                if (user != null)
                {
                    return StatusCode(200, user);
                }
                else
                    return StatusCode(400, "no user found");
            }
            catch (Exception)
            {

                throw;
            }
        }


        ////Authenticate user
        //[AllowAnonymous]
        [HttpPost,Route("Authentication")]

        public IActionResult Authentication([FromBody] AuthRequest authRequest)
        {
            AuthResponse authResponse = null;
            User? user = _userService.ValidateUser(authRequest.UserName, authRequest.Password);

            if(user != null) 
            { 
                string jwtToken = GetToken(user);
                authResponse = new AuthResponse()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Token = jwtToken
                };

            }
            return StatusCode(200, authResponse);

        }


        private string GetToken(User? user)
        {
            //JWT token : [ Header + payload(claims) + signature ]
            var issuer = configuration["Jwt:Issuer"];
            var audience =  configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            //symmetric encryption : same key for encryption and decryption
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );

            //this claims used to get the current user in the controllers
            var subject = new ClaimsIdentity(new[]
            {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                    });

            var expires = DateTime.UtcNow.AddMinutes(10);

            //descriptor : a piece of stored data the indicates how other data stored. (2nd part : payload)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            //3rd part : signature
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }






    }
}
