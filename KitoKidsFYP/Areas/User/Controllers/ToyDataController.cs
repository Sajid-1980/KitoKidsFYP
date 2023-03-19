using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ToyDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
