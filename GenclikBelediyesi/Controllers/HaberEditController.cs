using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HaberEditController : Controller
    {
        public HaberEditController(GenclikBelediyesiContext db1) { db = db1; }


        private GenclikBelediyesiContext db;
        public IActionResult Index(int id)
        {
            TblHaberler temp = db.TblHaberler.FirstOrDefault(d => d.HaberId == id);
            if (temp == null) return Redirect("/HaberYonet/Index");
            return View(temp);
        }

        [HttpPost]
        public IActionResult Post10()
        {
            string currentID = "";
            try
            {
                currentID = Request.Form["currentID"];
                if (string.IsNullOrEmpty(currentID)) throw new Exception();
                TblHaberler temp = db.TblHaberler.FirstOrDefault(d => d.HaberId.ToString().Equals( currentID));
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
                db.SaveChanges();
                TempData["SuccessMessage"] = "Değişiklikler Başarılı!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

            }
            return Redirect("/HaberEdit/Index?id=" + currentID);
        }

    }
}
