using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GenclikBelediyesi.Controllers
{
    public class AdminGirisController : Controller
    {
        public AdminGirisController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("admin"))
            {
                return Redirect("/AdminPanel/Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post6()
        {
            var adminid = Request.Form["adminid"].ToString();
            var Sifre3 = Request.Form["Sifre3"].ToString();

            TblAdmin temp = db.TblAdmin.FirstOrDefault(d => d.adminid.Equals(adminid));
            if (temp == null)
            {
                TempData["ErrorMessage"] = "Geçersiz Kullanıcı Adı!";
                return RedirectToAction("Index");
            }
            if (!temp.Sifre3.Equals(Sifre3))
            {
                TempData["ErrorMessage"] = "Geçersiz Şifre!";
                return RedirectToAction("Index");
            }

            var claims = new List<Claim>
            {
                new Claim("id",temp.TblAdminId.ToString()),
                new Claim(ClaimTypes.Name,temp.adminid),
                new Claim(ClaimTypes.Role, "admin")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

            return Redirect("/AdminPanel/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/AdminGiris/Index");
        }
    }
}
