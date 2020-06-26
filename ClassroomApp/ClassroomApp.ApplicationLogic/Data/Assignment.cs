using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Classroom classroom { get; set; }
        public Teacher teacher { get; set; }
        public ICollection<Student> Students { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        
    }
}
