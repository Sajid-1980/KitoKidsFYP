using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class LevelOneController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public LevelOneController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>  FruitLevelOne()
        {

            ViewBag.Questions = _context.ClusterFruitLevel1s.ToList();
            return View();

        }
    }
}
