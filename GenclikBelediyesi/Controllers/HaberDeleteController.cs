using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HaberDeleteController : Controller
    {
        public HaberDeleteController(GenclikBelediyesiContext db1) { db = db1; }


        private GenclikBelediyesiContext db;
        public IActionResult Index(int id)
        {
            TblHaberler temp = db.TblHaberler.FirstOrDefault(d => d.HaberId == id);
            if (temp == null) return Redirect("/HaberYonet/Index");
            return View(temp);
        }

        [HttpPost]
        public IActionResult Post11()
        {
            try
            {
                db.Remove(db.TblHaberler.FirstOrDefault(d => d.HaberId.ToString().Equals(Request.Form["currentID"])));
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            return Redirect("/HaberYonet/Index");
        }
    }
}
