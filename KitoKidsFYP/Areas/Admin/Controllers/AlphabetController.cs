using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Admin.ViewModels;
using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlphabetController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public AlphabetController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAlphabetLevelOne()
        {
            return View();

        }

        [HttpPost]
        [ActionName("CreateAlphabetLevelOne")]
        public async Task<IActionResult> CreateAlphabetLevelOne(AlphaLevel1ViewModel vm)
        {
            var ShortPath = "wwwroot/alphaimg";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            AlphaLevel1 _question = new AlphaLevel1();
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Guid Random = Guid.NewGuid();
            string FilePath = Path.Combine(path, (Random + "___" + vm.Question.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.Question.CopyToAsync(stream);
            }
            ShortPath = "/alphaimg";
            _question.QuestionText = ShortPath + "/" + Random + "___" + vm.Question.FileName;


            _question.OptionA = vm.OptionA;
            _question.OptionB = vm.OptionB;
            _question.OptionC = vm.OptionC;
            _question.OptionD = vm.OptionD;
            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();

            return LocalRedirect("/Admin/Alphabet/Index");

        }



        public JsonResult AlphabetTable()
        {
            var alphabetsList = _context.AlphaLevel1s.ToList();
            return Json(new { data = alphabetsList });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {


            if (_context.AlphabetLevel1s == null)
            {
                return Problem("No Records are Found..");
            }
            var alphabet = await _context.AlphabetLevel1s.FindAsync(id);
            if (alphabet != null)
            {
                _context.AlphabetLevel1s.Remove(alphabet);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });

        }
    }
}
