using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChoiceA.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} is too short or too long")]
        [Remote("ValidateTitle", "Disciplines")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Annotation { get; set; }
        public int TeacherId { get; set; }
        //
        public Teacher Teacher { get; set; }
        public ICollection<StudentDiscipline> StudentDisciplines { get; set; }
    }
}
