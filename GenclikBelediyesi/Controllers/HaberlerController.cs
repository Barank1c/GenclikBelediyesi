using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using GenclikBelediyesi.Models;

namespace GenclikBelediyesi.Controllers
{
    public class HaberlerController : Controller
    {
        public HaberlerController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index(int page, string search, int? monthOfSelect, int? yearOfSelect)
        {
            if(monthOfSelect==null) monthOfSelect = 3; //default
            if(yearOfSelect==null) yearOfSelect = 2023; //default
            List<TblHaberler> temp;
            if (search == null || search == "")
            {
                temp = db.TblHaberler.Where(d => d.Aktif && d.BasTarih.Month == monthOfSelect && d.BasTarih.Year == yearOfSelect).ToList();
                search = "";
            }
            else
            {
                temp = db.TblHaberler.Where(d => d.Aktif && d.BasTarih.Month == monthOfSelect && d.BasTarih.Year == yearOfSelect && d.Baslik.Contains(search)).ToList();
            }

            if (page <= 0) {page = 1;}
            if(page> temp.Count/6.0) { page = temp.Count/6 + 1; }

            HaberlerModel haberlerModel = new HaberlerModel();
            haberlerModel.year = (int)yearOfSelect;
            haberlerModel.month = (int)monthOfSelect;
            haberlerModel.list = new PagedList<TblHaberler>(temp, page, 6);
            haberlerModel.search = search;

			return View(haberlerModel);
        }
    }
}
