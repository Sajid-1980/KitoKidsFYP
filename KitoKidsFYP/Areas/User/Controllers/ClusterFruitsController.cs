using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ClusterFruitsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
