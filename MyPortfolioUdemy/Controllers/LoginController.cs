using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace MyPortfolioUdemy.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.UserName == username);
            if (admin == null || admin.Password != password)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, username),
        new Claim("AdminId", admin.AdminId.ToString())
    };

            var identity = new ClaimsIdentity(claims, "Cookies"); // veya ne kullanıyorsan
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal);

            return RedirectToAction("Index", "Statistic");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Login");
        }
    }
}