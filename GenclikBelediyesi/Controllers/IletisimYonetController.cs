using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class IletisimYonetController : Controller
    {
        public IletisimYonetController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index(int page, string? search)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (search == null || search == "")
            {
                TempData["search"] = "";
                return View(new PagedList<Tbiletisim>(db.Tbiletisim.ToList(), page, 25));
            }
            else
            {
                TempData["search"] = search;
                return View(new PagedList<Tbiletisim>(db.Tbiletisim.Where(d => d.iletisimAdiniz.Contains(search)).ToList(), page, 25));
            }
        }
    }
}
