using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.ViewModels
{
    public class AlphaLevel1ViewModel
    {
        [Required]
        public IFormFile Question { get; set; }

        [Required]
        public string OptionA { get; set; }
        [Required]
        public string OptionB { get; set; }
        [Required]
        public string OptionC { get; set; }
        [Required]
        public string OptionD { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }
    }
}
