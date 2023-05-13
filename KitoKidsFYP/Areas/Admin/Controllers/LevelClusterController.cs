using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Admin.ViewModels;
using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LevelClusterController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public LevelClusterController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateLevel3()
        {
            return View();

        }

        [HttpPost]
        
        public async Task<IActionResult> Level3Post(LevelVm vm)
        {
            var ShortPath = "wwwroot/Files";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            Level3Cluster _question = new Level3Cluster();

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Guid Random = Guid.NewGuid();
            string FilePath = Path.Combine(path, (Random + "___" + vm.Audios.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.Audios.CopyToAsync(stream);
            }
            ShortPath = "/Files";
            _question.QuestionAudio = ShortPath + "/" + Random + "___" + vm.Audios.FileName;


            _question.QuestionText =   vm.Question;


            _question.OptionA = vm.OptionA;
            _question.OptionB = vm.OptionB;
             
            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();

            return LocalRedirect("/Admin/LevelCluster/Index");

        }



        public JsonResult Level3Table()
        {
            var alphabetsList = _context.Level3Clusters.ToList();
            return Json(new { data = alphabetsList });
        }



        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{


        //    if (_context.AlphabetLevel1s == null)
        //    {
        //        return Problem("No Records are Found..");
        //    }
        //    var alphabet = await _context.AlphabetLevel1s.FindAsync(id);
        //    if (alphabet != null)
        //    {
        //        _context.AlphabetLevel1s.Remove(alphabet);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Json(new { success = true, message = "Delete successful" });

        //}
    }
}
