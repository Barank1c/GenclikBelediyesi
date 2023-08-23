using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    public class GirisYapController : Controller
    {
        private readonly SignInManager<TblUye> _signInManager;
        private GenclikBelediyesiContext db;
        public GirisYapController(SignInManager<TblUye> signInManager, GenclikBelediyesiContext db1)
        {
            _signInManager = signInManager;
            db = db1;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post4()
        {
            var tcNo = Request.Form["TcNo"].ToString();
            var sifre = Request.Form["Sifre"].ToString();


            if (string.IsNullOrEmpty(tcNo) || string.IsNullOrEmpty(sifre))
            {
                TempData["ErrorMessage"] = "Lütfen bütün alanları Doldurun!";
                return RedirectToAction("Index");
            }

            var result = await _signInManager.PasswordSignInAsync(tcNo, sifre, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Uyumsuz Kimlik veya Şifre.";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
