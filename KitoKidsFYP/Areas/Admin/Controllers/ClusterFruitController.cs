using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Admin.ViewModels;
using KitoKidsFYP.Data;
using Microsoft.AspNetCore.Mvc;

namespace KitoKidsFYP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClusterFruitController : Controller
    {

        public readonly KitoKidsFYPContext _context;
        private readonly IWebHostEnvironment _environment;


        public ClusterFruitController(KitoKidsFYPContext context , IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreateClasterFruitLevelOne()
        {
            return View();

        }

        [HttpPost]
        [ActionName("CreateClasterFruitLevelOne")]
        public async Task<IActionResult> CreateClasterFruitLevelOne(ClusterFruitLevel1ViewModel vm)
        {
            var ShortPath = "wwwroot/Files";
            string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
            ClusterFruitLevel1 _question = new ClusterFruitLevel1();
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


            return LocalRedirect("/Admin/ClusterFruit/Index");
        }


        // [HttpGet]

        //public JsonResult GetAllQuizzes()
        //{
        //    var questList = _context.ClusterFruitLevel1s.ToList();
        //    return Json(new { data = questList });
        //}


        public JsonResult FruitTable()
        {
            var fruitlist = _context.ClusterFruitLevel1s.ToList();
            return Json(new { data = fruitlist });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {


            if (_context.ClusterFruitLevel1s == null)
            {
                return Problem("No Records are Found..");
            }
            var site = await _context.ClusterFruitLevel1s.FindAsync(id);
            if (site != null)
            {
                _context.ClusterFruitLevel1s.Remove(site);
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });

        }





        public async Task<IActionResult> CreateLevel2()
        {
            return View();

        }


        [HttpPost]
        public IActionResult CreateLevel2(ClusterFruitLevel2ViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var level2 = new ClusterFruitLevel2
            {
                Name = vm.Name,
                ImageUrl = stringFileName

            };
            _context.ClusterFruitLevel2s.Add(level2);
            _context.SaveChanges();
            return LocalRedirect("/Admin/ClusterFruit/IndexLevel2");

        }
        private string UploadFile(ClusterFruitLevel2ViewModel vm)
        {
            string fileName = null;
            
            if (vm.ImageUrl != null)
            {
                string uploadDir = Path.Combine(_environment.WebRootPath, "image");
                fileName = Guid.NewGuid().ToString() + "_" + vm.ImageUrl.FileName;
                 string allS = fileName;
                string filePath = Path.Combine(uploadDir, allS);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    vm.ImageUrl.CopyTo(filestream);
                 }
            }

            return fileName;

        }

        public async Task<IActionResult> IndexLevel2()
        {
            return View();

        }



        public JsonResult FruitTableLevel2()
        {
            var fruitlist = _context.ClusterFruitLevel2s.ToList();
            return Json(new { data = fruitlist });
        }



        // Level 3


        public async Task<IActionResult> ClusterIndexLevel3()
        {
            return View();

        }

        public async Task<IActionResult> CreateClasterFruitLevelTwo()
        {
            return View();

        }

        


        //public async Task<IActionResult> CreateClusterLevelThree()
        //{
        //    return View();

        //}

        //[HttpPost]
        //[ActionName("CreateClusterLevelThree")]
        //public async Task<IActionResult> CreateClusterLevelThree(ClusterFruitLevel3ViewModel vm)
        //{
        //    var ShortPath = "wwwroot/Files";
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), ShortPath);
             

        //    ClusterFruitLevel3 _question = new ClusterFruitLevel3();

        //    _question.QuestionText = vm.Question;


        //    //create folder if not exist
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);
        //    Guid Random = Guid.NewGuid();
        //    string FilePath = Path.Combine(path, (Random + "___" + vm.QuestionAud.FileName));

        //    using (var stream = new FileStream(FilePath, FileMode.Create))
        //    {
        //        await vm.QuestionAud.CopyToAsync(stream);
        //    }
        //    ShortPath = "/Files";
        //    _question.QuestionAudio = ShortPath + "/" + Random + "___" + vm.QuestionAud.FileName;



          
        //    _question.OptionA = vm.OptionA;
        //    _question.OptionB = vm.OptionB;
             
        //    _question.CorrectAnswer = vm.CorrectAnswer;

        //    _context.Add(_question);
        //    await _context.SaveChangesAsync();

        //    return LocalRedirect("/Admin/ClusterFruit/ClusterIndexLevel3");

        //}




        public async Task<IActionResult> CreateLevel3()
        {
            return View();

        }


        [HttpPost]
         public async Task<IActionResult>  Level4(ClusterFruitLevel4ViewModel vm)
        {
             
            ClusterFruitLevel3 _question = new ClusterFruitLevel3();
            //create folder if not exist
           
            _question.QuestionText =  vm.Question;


            _question.OptionA = vm.OptionA;
            _question.OptionB = vm.OptionB;
             
            _question.CorrectAnswer = vm.CorrectAnswer;

            _context.Add(_question);
            await _context.SaveChangesAsync();

            return LocalRedirect("/Admin/ClusterFruit/ClusterIndexLevel3");

        }


        public JsonResult TableLevel3()
        {
            var fruitlist = _context.ClusterFruitsLevel3s.ToList();
            return Json(new { data = fruitlist });
        }

    }
}
