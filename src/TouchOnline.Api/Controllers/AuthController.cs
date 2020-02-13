using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TouchOnline.Cqrs.Client.User;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Keyboard;
using TouchOnline.CqrsClient.User;

namespace DigiteMais.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IProcessor _processor;
        private readonly IConfiguration _config;

        public AuthController(IProcessor processor, IConfiguration config)
        {
            _processor = processor;
            _config = config;
        }
        [HttpPost("Register")]
        public IActionResult Register(Register registerUser)
        {
            //Validate request
            registerUser.Email = registerUser.Email.ToLower();
            if (_processor.Get(new UserExists(registerUser.Email)))
                return BadRequest("Email alredy exists");

            _processor.Send(registerUser);
            var userToReturn = _processor.Get(new GetUser(registerUser.Email));
            return Ok(userToReturn);
        }

        [HttpPost("Login")]
        public IActionResult Login(Login userLogin)
        {
          //  _processor.Send(new InsertKeyboards());
            var userfromDisplay = _processor.Get(userLogin);
            if (userfromDisplay == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userfromDisplay.Id.ToString()),
                new Claim(ClaimTypes.Name, userfromDisplay.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDecriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                userfromDisplay
            });

        }
    }
}