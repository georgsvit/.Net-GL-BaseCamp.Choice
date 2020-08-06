using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} is too short or too long")]
        [Remote("ValidateName", "Students")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} name is too short or too long")]
        public string Group { get; set; }
        //
        public ICollection<StudentDiscipline> StudentDisciplines { get; set; }
        public AppUser AspNetUser { set; get; }
    }
}
