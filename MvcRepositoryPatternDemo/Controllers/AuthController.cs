
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcRepositoryPatternDemo.DAL;
using MvcRepositoryPatternDemo.Models;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MvcRepositoryPatternDemo.Controllers
{
    public class AuthController : Controller
    {
        private readonly BookContext _bookContext;
        private readonly IConfiguration _configuration;

        public AuthController(BookContext bookContext, IConfiguration configuration)
        {
            _bookContext = bookContext;
            _configuration = configuration;
        }
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login(Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (loginViewModel.UserName == "admin" && loginViewModel.Password == "admin@1234")
            {
                TempData["Username"] = loginViewModel.UserName;
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "admin"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

                return RedirectToAction("Index","Book", loginViewModel);
            }
            else
            {
                return Unauthorized();
            }
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("");
        }
        #endregion
    }
}
