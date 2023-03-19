using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class AlphabetLevelOneController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public AlphabetLevelOneController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AlphabetsLevelOne()
        {

            ViewBag.Questions = _context.AlphaLevel1s.ToList();
            return View();

        }
    }
}
