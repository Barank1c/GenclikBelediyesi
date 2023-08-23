using GenclikBelediyesi.Models;
using GenclikBelediyesi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GenclikBelediyesi.Controllers
{
    public class AraController : Controller
    {

        public AraController(GenclikBelediyesiContext db1) { db = db1; }

        private GenclikBelediyesiContext db;

        public IActionResult Index(int page, string search)
        {

            if (string.IsNullOrEmpty(search))
            {
                return Redirect("/Home/Index");
            }
            List<AraModel2> links = new List<AraModel2>();


            //I did not add hakkimizda and iletisim to database so i handled manually
            string hakkimizda = "HakkımızdaLorem Ipsum, bilinmeyen bir matbaacının bir tip numune kitabı yapmak için bir yazı galerisini alıp karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur.MİSYONLorem Ipsum Sit Amet ConsecteturLorem Ipsum, bilinmeyen bir matbaacının bir tip numune kitabı yapmak için bir yazı galerisini alıp karıştırdığı 1500'lerden beri endüstrinin standart sahte metni olmuştur.VİZYON";
            string iletisim = "İLETİŞİM BİLGİLERİBirim AdıAdresLorem Ipsum , basım ve dizgi endüstrisininTelefon0 232 293 49 92E-MAİLgenclikbelediyesi@izmir.bel.trAdınızSoyadınıze-PostaMesajKişisel Verilerin Korunması";
            if (hakkimizda.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                AraModel2 temp1 = new AraModel2();
                temp1.link = "/Hakkimizda/Index";
                temp1.descp = "Hakkımızda";
                links.Add(temp1);
            }
            if (iletisim.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                AraModel2 temp1 = new AraModel2();
                temp1.link = "/Iletisim/Index";
                temp1.descp = "İletişim";
                links.Add(temp1);
            }

            foreach (var i in db.TblHaberler.Where(d => d.Aktif))
            {
                if (i.Baslik.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || i.Icerik.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || i.Icerik1.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || i.Icerik2.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    AraModel2 temp1 = new AraModel2();
                    temp1.link = "/HaberlerDetay/Index?id=" + i.HaberId;
                    temp1.descp = "Haber: " + i.Baslik;
                    links.Add(temp1);
                }
            }

            if (page <= 0) page = 1;
            if(page>links.Count/15.0) page = links.Count/15 + 1;

            AraModel temp = new AraModel();
            temp.Search = search;
            temp.links = new PagedList<AraModel2>(links, page, 15);
            return View(temp);
        }
    }
}
