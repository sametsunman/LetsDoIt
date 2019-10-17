using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.API.Models;
using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LDI.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        public IUnitOfWork service;

        public UserController(IUnitOfWork _service)
        {
            service = _service;

        }


        [HttpGet("GetRoles/{id}")]
        public ActionResult<List<int>> GetRoles(int id)
        {
            return service.User.GetRoles(id).Select(x => x.ID).ToList();
        }


        // POST: api/User
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(LoginViewModel value)
        {
            if (ModelState.IsValid)
            {
                User user = service.User.Get(x => x.Username == value.Username && x.Password == value.Password);

                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, value.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: "asd",
                    audience: "asd",
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(30), 
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("letsdoit-asnus-com")),
                            SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();

        }

    }
}
