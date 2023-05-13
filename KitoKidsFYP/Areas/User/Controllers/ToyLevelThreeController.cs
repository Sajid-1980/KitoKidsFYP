using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ToyLevelThreeController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public ToyLevelThreeController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ToysLevelThree()
        {

            return View();

        }
    }
}
