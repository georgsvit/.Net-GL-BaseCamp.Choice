using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.ChoiceA.Models
{
    public class StudentDiscipline
    {
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        //
        public Student Student { get; set; }
        public Discipline Discipline { get; set; }
        //
        public StudentDiscipline() { }
        public StudentDiscipline(Student student, Discipline discipline)
        {
            Student = student;
            StudentId = student.Id;
            Discipline = discipline;
            DisciplineId = discipline.Id;
        }
    }
}
