using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class ClusterFruitLevelThreeController : Controller
    {
       
        public readonly KitoKidsFYPContext _context;


        public ClusterFruitLevelThreeController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Level3()
        {
            ViewBag.Questions = _context.ClusterFruitsLevel3s.ToList();
            return View();
            
        }

        



        //

        public IActionResult Level5()
        {
            ViewBag.Questions = _context.ClusterFruitsLevel3s.ToList();
            return View();

        }

    }
}
