using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
	public class HaberlerDetayController : Controller
	{
		public HaberlerDetayController(GenclikBelediyesiContext db1) { db = db1; }

		private GenclikBelediyesiContext db;
		public IActionResult Index(int id)
		{
			List<TblHaberler> temp = db.TblHaberler.Where(d => d.Aktif).ToList();
			int index = temp.FindIndex(d => d.HaberId == id);
			if (index == -1) return Redirect("/Home/Error");
			ViewData["index"] = index;
			return View(temp);
		}
	}
}
