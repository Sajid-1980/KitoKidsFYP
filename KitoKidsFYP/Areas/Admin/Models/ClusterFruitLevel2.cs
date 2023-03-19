using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.Models
{
    public class ClusterFruitLevel2
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
