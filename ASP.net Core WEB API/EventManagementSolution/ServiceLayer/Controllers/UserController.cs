using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoRepo<UserInfo> _repo;
        private readonly IConfiguration _config;

        public UserController(IUserInfoRepo<UserInfo> repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _repo.GetAllUsers();
            return users != null && users.Any() ? Ok(users) : NotFound();
        }

        [HttpGet("GetByEmail/{email}")]
        public IActionResult Get(string email)
        {
            var user = _repo.GetUserByEmail(email);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var created = _repo.AddUser(user);
                return Created(HttpContext.Request.Path, created);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var updated = _repo.UpdateUser(user);
                return updated != null ? Accepted(HttpContext.Request.Path, updated) : NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{email}")]
        public IActionResult Delete(string email)
        {
            var deleted = _repo.DeleteUser(email);
            return deleted != null ? Ok(deleted) : NotFound();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserInfo input)
        {
            var user = _repo.ValidateUser(input.EmailId);
            if (user != null && user.Password == input.Password)
            {
                var token = GenerateToken(user);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [NonAction]
        private string GenerateToken(UserInfo user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
