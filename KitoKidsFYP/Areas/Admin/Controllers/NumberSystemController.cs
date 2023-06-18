using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Admin.ViewModels;
using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NumberSystemController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public NumberSystemController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateNumberSystemLevelOne()
        {
            return View();
        }
        [HttpPost]
        [ActionName("CreateNumberSystemLevelOne")]
        public async Task<IActionResult> CreateNumberSystemLevelOne(NumberSystemLevel1ViewModel vm)
        {
            var ShortPath = "wwwroot/alphaimg";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            NumberSystemLevel1 _question = new NumberSystemLevel1();
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Guid Random = Guid.NewGuid();
            string FilePath = Path.Combine(path, (Random + "___" + vm.Question.FileName));
            string FilePaths = Path.Combine(path, (Random + "___" + vm.QuestionAudio.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.Question.CopyToAsync(stream);
            }
            using (var stream = new FileStream(FilePaths, FileMode.Create))
            {
                await vm.QuestionAudio.CopyToAsync(stream);
            }
            ShortPath = "/alphaimg";
            _question.QuestionText = ShortPath + "/" + Random + "___" + vm.Question.FileName;
            _question.QuestionAudios = ShortPath + "/" + Random + "___" + vm.QuestionAudio.FileName;


            _question.OptionA = vm.OptionA;
            _question.OptionB = vm.OptionB;
            _question.OptionC = vm.OptionC;
            _question.OptionD = vm.OptionD;
            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();

            return LocalRedirect("/Admin/NumberSystem/Index");

        }


        public JsonResult AlphabetTable()
        {
            var alphabetsList = _context.NumberSystemLevels.ToList();
            return Json(new { data = alphabetsList });
        }



    }
}
