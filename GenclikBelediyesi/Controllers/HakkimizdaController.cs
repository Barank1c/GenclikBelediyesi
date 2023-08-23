using Microsoft.AspNetCore.Mvc;

namespace GenclikBelediyesi.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
