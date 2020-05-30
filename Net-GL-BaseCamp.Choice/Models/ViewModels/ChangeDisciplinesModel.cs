using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.Choice.Models.ViewModels
{
    public class ChangeDisciplinesModel
    {
        public IEnumerable<Discipline> Selected { get; set; }
        public IEnumerable<Discipline> Unselected { get; set; }
        public int StudentId { get; set; }

        public ChangeDisciplinesModel(IEnumerable<Discipline> selected, 
                                      IEnumerable<Discipline> unselected, 
                                      int studentId)
        {
            Selected = selected;
            Unselected = unselected;
            StudentId = studentId;
        }
    }
}
