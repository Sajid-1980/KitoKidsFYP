using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ToyLevelOneController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public ToyLevelOneController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ToysLevelOne()
        {

            ViewBag.Questions = _context.ToysLevel1s.ToList();
            return View();

        }
    }
}
