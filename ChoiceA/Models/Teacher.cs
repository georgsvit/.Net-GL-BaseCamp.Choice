using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChoiceA.Models
{
    public class Teacher
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} is too short or too long")]
        [Remote("ValidateName", "Teachers")]
        public string Name { set; get; }
        //
        public ICollection<Discipline> Disciplines { get; set; }
    }
}
