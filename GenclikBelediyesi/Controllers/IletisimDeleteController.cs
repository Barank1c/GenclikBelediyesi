using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IletisimDeleteController : Controller
    {
        public IletisimDeleteController(GenclikBelediyesiContext db1) { db = db1; }


        private GenclikBelediyesiContext db;
        public IActionResult Index(int id)
        {
            Tbiletisim temp = db.Tbiletisim.FirstOrDefault(d => d.TbiletisimId == id);
            if (temp == null) return Redirect("/IletisimYonet/Index");
            return View(temp);
        }

        [HttpPost]
        public IActionResult Post8()
        {
            try
            {
                db.Remove(db.Tbiletisim.FirstOrDefault(d => d.TbiletisimId.ToString().Equals(Request.Form["currentID"])));
                db.SaveChanges();
            }
            catch (Exception )
            {
                return RedirectToAction("Error", "Home");
            }
            
            return Redirect("/IletisimYonet/Index");
        }

    }
}
