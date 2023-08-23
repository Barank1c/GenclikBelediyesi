using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IletisimEditController : Controller
    {
        public IletisimEditController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;
        public IActionResult Index(int id)
        {
            Tbiletisim temp = db.Tbiletisim.FirstOrDefault(d => d.TbiletisimId == id);
            if (temp == null) return Redirect("/IletisimYonet/Index");
            return View(temp);
        }

        [HttpPost]
        public IActionResult Post7()
        {
            string currentID="";

            try
            {
                string iletisimAdiniz = Request.Form["iletisimAdiniz"];
                string iletisimSoyadiniz = Request.Form["iletisimSoyadiniz"];
                string iletisimMailiniz = Request.Form["iletisimMailiniz"];
                string iletisimMesaj = Request.Form["iletisimMesaj"];
                string reply = Request.Form["reply"];
                currentID = Request.Form["currentID"];

                //The Program Should Send Email Here, But i did not add it!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                TempData["SuccessMessage"] = "Yanıt Gönderildi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

            }
            return Redirect("/IletisimEdit/Index?id=" + currentID);
        }
    }
}
