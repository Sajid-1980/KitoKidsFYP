using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ToyLevelTwoController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public ToyLevelTwoController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ToysLevelTwo()
        {

            ViewBag.Questions = _context.ToysLevel2s.ToList();
            return View();

        }
    }
}
