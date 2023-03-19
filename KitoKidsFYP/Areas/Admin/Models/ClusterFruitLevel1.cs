﻿using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.Models
{
    public class ClusterFruitLevel1
    {

        [Key]
        public int Id { get; set; }
       
        [Required]
        public string QuestionText { get; set; }

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
