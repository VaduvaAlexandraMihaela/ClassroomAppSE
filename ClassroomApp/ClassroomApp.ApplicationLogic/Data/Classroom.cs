using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
   public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Group group { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
