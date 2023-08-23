using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    public class IletisimController : Controller
    {
        public IletisimController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post3()
        {
            try
            {
                var iletisimAdiniz = Request.Form["iletisimAdiniz"].ToString();
                var iletisimSoyadiniz = Request.Form["iletisimSoyadiniz"].ToString();
                var iletisimMailiniz = Request.Form["iletisimMailiniz"].ToString();
                var iletisimMesaj = Request.Form["iletisimMesaj"].ToString();

                Tbiletisim temp = new Tbiletisim();
                temp.iletisimAdiniz = iletisimAdiniz;
                temp.iletisimSoyadiniz = iletisimSoyadiniz;
                temp.iletisimMailiniz = iletisimMailiniz;
                temp.iletisimMesaj = iletisimMesaj;

                db.Tbiletisim.Add(temp);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Formunuz Gönderildi!";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
