using Application_Core.Data;
using Application_Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Application_Core.Controllers
{
    public class LoginController : Controller
    {
        DepartContext context = new DepartContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();  
        }


        public async Task<IActionResult> Login(Admin admin) 
        {
            var info = context.Admins.FirstOrDefault(x=>x.UserName == admin.UserName && x.Password == admin.Password);
            if (info != null) 
            {
                var claims = new List<Claim>
                { 
                    new Claim(ClaimTypes.Name, admin.UserName)
                };
                var usercontrol = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(usercontrol);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personel");
            };

            return View();  
        }
    }
}
