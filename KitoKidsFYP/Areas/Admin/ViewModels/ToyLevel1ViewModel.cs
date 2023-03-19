using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.ViewModels
{
    public class ToyLevel1ViewModel
    {
        [Required]
        public IFormFile Question { get; set; }

        [Required]
        public IFormFile OptionA { get; set; }
        [Required]
        public IFormFile OptionB { get; set; }
        [Required]
        public IFormFile OptionC { get; set; }
        [Required]
        public IFormFile OptionD { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

    }
}
