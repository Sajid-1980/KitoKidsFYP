using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class NumberSystemLevelOneController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public NumberSystemLevelOneController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> NumberLevelOne()
        {

            ViewBag.Questions = _context.NumberSystemLevels.ToList();
            return View();

        }
    }
}
