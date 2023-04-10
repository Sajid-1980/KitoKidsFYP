using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class AlphabetLevelTwoController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public AlphabetLevelTwoController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult AlphabetLevelTwo()
        {
            return View();
        }

        
    }
}
