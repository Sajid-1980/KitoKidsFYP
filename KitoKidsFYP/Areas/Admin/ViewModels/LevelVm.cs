using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.ViewModels
{
    public class LevelVm
    {
        [Required]
        public IFormFile Audios { get; set; }
        [Required]
        public string Question { get; set; }

        [Required]
        public string OptionA { get; set; }
        [Required]
        public string OptionB { get; set; }
        

        [Required]
        public string CorrectAnswer { get; set; }
    }
}
