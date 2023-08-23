using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GenclikBelediyesi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HaberYonetController : Controller
    {

        public HaberYonetController(GenclikBelediyesiContext db1) { db = db1; }

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
                return View(new PagedList<TblHaberler>(db.TblHaberler.ToList(), page, 25));
            }
            else
            {
                TempData["search"] = search;
                return View(new PagedList<TblHaberler>(db.TblHaberler.Where(d => d.Baslik.Contains(search)).ToList(), page, 25));
            }
        }
    }
}
