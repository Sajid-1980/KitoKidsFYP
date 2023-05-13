﻿using System.ComponentModel.DataAnnotations;

namespace KitoKidsFYP.Areas.Admin.Models
{
    public class Level4Cluster
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
        public string CorrectAnswer { get; set; }
    }
}
