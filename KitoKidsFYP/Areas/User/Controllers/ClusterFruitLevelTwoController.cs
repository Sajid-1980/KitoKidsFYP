using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]

    public class ClusterFruitLevelTwoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
