using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Panel()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Mainpage()
        {
            return Redirect("/");
        }

    }
}
