using GenclikBelediyesi.Models;
using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenclikBelediyesi.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index()
        {
            HomeModel model = new HomeModel(db);
            return View(model);
        }

        [HttpPost]
        public IActionResult Post1()
        {
            return Redirect("/Haberler/Index?monthOfSelect=3&yearOfSelect=2023");
        }

        [HttpPost]
        public IActionResult Post2()
        {
            return Redirect("/Home/Index"); // I didn't do that part
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}