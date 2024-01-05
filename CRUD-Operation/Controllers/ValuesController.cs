using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProductContext _context;

        public ValuesController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate( Login model)
        {
            var user = _context.Register.FirstOrDefault(value => value.Email == model.Username && value.Password == model.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("thisismysecretkeycreatedbyvijay-45234-5435-234-5345-3245-23452345-345-23453245");
            var tokenDescrptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                    }
                ),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescrptior);
            string finalToken = tokenHandler.WriteToken(token);
            return Ok(finalToken);
        }
    }
}
