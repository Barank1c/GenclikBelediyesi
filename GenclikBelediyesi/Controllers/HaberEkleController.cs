using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HaberEkleController : Controller
    {
        public HaberEkleController(GenclikBelediyesiContext db1) { db = db1; }


        private GenclikBelediyesiContext db;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post9()
        {
            try
            {
                TblHaberler temp = new TblHaberler();
                DateTime BasTarih1 = DateTime.Parse(Request.Form["BasTarih"]);
                DateTime BitTarih1 = DateTime.Parse(Request.Form["BitTarih"]);
                bool Aktif1 = Request.Form["Aktif"].Equals("0") ? false : true;
                temp.Baslik = Request.Form["Baslik"];
                temp.Icerik = Request.Form["Icerik"];
                temp.Icerik1 = Request.Form["Icerik1"];
                temp.Icerik2 = Request.Form["Icerik2"];
                temp.Aktif = Aktif1;
                temp.BasTarih = BasTarih1;
                temp.BitTarih = BitTarih1;
                temp.Foto1 = Request.Form["Foto1"];
                temp.Foto2 = Request.Form["Foto2"];
                temp.Foto3 = Request.Form["Foto3"];
                temp.Foto4 = Request.Form["Foto4"];
                temp.Foto5 = Request.Form["Foto5"];
                temp.Foto6 = Request.Form["Foto6"];
                temp.Foto7 = Request.Form["Foto7"];
                temp.Foto8 = Request.Form["Foto8"];
                db.TblHaberler.Add(temp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

            }
            return Redirect("/HaberYonet/Index");
        }
    }
}
