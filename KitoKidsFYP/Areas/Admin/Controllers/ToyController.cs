using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Admin.ViewModels;
using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToyController : Controller
    {

        public readonly KitoKidsFYPContext _context;


        public ToyController(KitoKidsFYPContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateToyLevelOne()
        {
            return View();

        }

        [HttpPost]
        [ActionName("CreateToyLevelOne")]
        public async Task<IActionResult> CreateToyLevelOne(ToyLevel1ViewModel vm)
        {
            var ShortPath = "wwwroot/Files";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            ToysLevel1 _question = new ToysLevel1();
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Guid Random = Guid.NewGuid();
            string FilePath = Path.Combine(path, (Random + "___" + vm.Question.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.Question.CopyToAsync(stream);
            }
            ShortPath = "/Files";
            _question.QuestionText = ShortPath + "/" + Random + "___" + vm.Question.FileName;

            //For Option A
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionA.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionA.CopyToAsync(stream);
            }
            _question.OptionA = ShortPath + "/" + Random + "___" + vm.OptionA.FileName;

            //For Option B
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionB.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionB.CopyToAsync(stream);
            }
            _question.OptionB = ShortPath + "/" + Random + "___" + vm.OptionB.FileName;

            //For Option C
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionC.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionC.CopyToAsync(stream);
            }
            _question.OptionC = ShortPath + "/" + Random + "___" + vm.OptionC.FileName;

            //For Option D
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionD.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionD.CopyToAsync(stream);
            }
            _question.OptionD = ShortPath + "/" + Random + "___" + vm.OptionD.FileName;

            //string sourceFile = @"wwwroot/Files/" + vm.OptionA.FileName ;
            //System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            //if (fi.Exists)
            //{
            //    string filename = Guid.NewGuid().ToString() + ".jpg";
            //    path = path + filename;
            //    fi.MoveTo(@"wwwroot/" + CommonConstants.ItemImagePath + filename);
            //}
            //obj.Image = path;

            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();


            return LocalRedirect("/Admin/Toy/Index");
        }


        // [HttpGet]

        //public JsonResult GetAllQuizzes()
        //{
        //    var questList = _context.ClusterFruitLevel1s.ToList();
        //    return Json(new { data = questList });
        //}


        public JsonResult ToyTable()
        {
            var  toysList = _context.ToysLevel1s.ToList();
            return Json(new { data = toysList });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {


            if (_context.ToysLevel1s == null)
            {
                return Problem("No Records are Found..");
            }
            var toys = await _context.ToysLevel1s.FindAsync(id);
            if (toys != null)
            {
                _context.ToysLevel1s.Remove(toys);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });

        }

        //=================================
        //           LevelTwo
        //=================================


        public IActionResult ToyLevelTwoIndex()
        {
            return View();
        }

         


        public async Task<IActionResult> CreateToyLevelTwo()
        {
            return View();

        }


        [HttpPost]
        [ActionName("CreateToyLevelTwo")]
        public async Task<IActionResult> CreateToyLevelTwo(ToyLevel1ViewModel vm)
        {
            var ShortPath = "wwwroot/Files";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            ToysLevel2 _question = new ToysLevel2();
            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Guid Random = Guid.NewGuid();
            string FilePath = Path.Combine(path, (Random + "___" + vm.Question.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.Question.CopyToAsync(stream);
            }
            ShortPath = "/Files";
            _question.QuestionText = ShortPath + "/" + Random + "___" + vm.Question.FileName;

            //For Option A
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionA.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionA.CopyToAsync(stream);
            }
            _question.OptionA = ShortPath + "/" + Random + "___" + vm.OptionA.FileName;

            //For Option B
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionB.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionB.CopyToAsync(stream);
            }
            _question.OptionB = ShortPath + "/" + Random + "___" + vm.OptionB.FileName;

            //For Option C
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionC.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionC.CopyToAsync(stream);
            }
            _question.OptionC = ShortPath + "/" + Random + "___" + vm.OptionC.FileName;

            //For Option D
            Random = Guid.NewGuid();
            FilePath = Path.Combine(path, (Random + "___" + vm.OptionD.FileName));

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await vm.OptionD.CopyToAsync(stream);
            }
            _question.OptionD = ShortPath + "/" + Random + "___" + vm.OptionD.FileName;

            //string sourceFile = @"wwwroot/Files/" + vm.OptionA.FileName ;
            //System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            //if (fi.Exists)
            //{
            //    string filename = Guid.NewGuid().ToString() + ".jpg";
            //    path = path + filename;
            //    fi.MoveTo(@"wwwroot/" + CommonConstants.ItemImagePath + filename);
            //}
            //obj.Image = path;

            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();


            return LocalRedirect("/Admin/Toy/ToyLevelTwoIndex");
        }

        public JsonResult Level2Table()
        {
            var toysList = _context.ToysLevel2s.ToList();
            return Json(new { data = toysList });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteLevelTwo(int id)
        {


            if (_context.ToysLevel2s == null)
            {
                return Problem("No Records are Found..");
            }
            var toys = await _context.ToysLevel2s.FindAsync(id);
            if (toys != null)
            {
                _context.ToysLevel2s.Remove(toys);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });

        }

    }
}
