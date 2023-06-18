using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class AlphabetLevelThreeController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public AlphabetLevelThreeController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult AlphabetLevelThree()
        {
            return View();
        }

        
    }
}
