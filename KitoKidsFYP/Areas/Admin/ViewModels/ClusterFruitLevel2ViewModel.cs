using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.ViewModels
{
    public class ClusterFruitLevel2ViewModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }

    }
}
