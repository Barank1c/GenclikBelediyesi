using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    public class UyeOlController : Controller
    {
        private readonly UserManager<TblUye> _userManager;
        private GenclikBelediyesiContext db;

        public UyeOlController(UserManager<TblUye> userManager, GenclikBelediyesiContext db)
        {
            _userManager = userManager;
            this.db = db;
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
        public async Task<IActionResult> Post5()
        {
            try
            {
                var adSoyad = Request.Form["AdSoyad"].ToString();
                var tcNo = Request.Form["TcNo"].ToString();
                var dogumTarih = DateTime.Parse(Request.Form["DogumTarih"]);
                var telefon = Request.Form["Telefon"].ToString();
                var sifre = Request.Form["Sifre"].ToString();

                var user = new TblUye
                {
                    Id = adSoyad,
                    UserName = tcNo,
                    DogumTarih = dogumTarih,
                    PhoneNumber = telefon
                };
                var result = await _userManager.CreateAsync(user, sifre);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Kaydınız Tamamlandı!";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Kaydınız Başarısız!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Kaydınız Başarısız!";
            return RedirectToAction("Index");
        }

    }
}
