using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.User.Controllers
{
    [Area("User")]
    public class Level4ClusterController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public Level4ClusterController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Level3Cluster()
        {

            ViewBag.Questions = _context.Level3Clusters.ToList();
            return View();

        }
    }
}
