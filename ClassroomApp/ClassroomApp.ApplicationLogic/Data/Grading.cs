using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
   public class Grading
    {
        public Guid Id { get; set; }
        public Assignment Assignment { get; set; }
        public Student student { get; set; }
        public int Grade { get; set; }
    }
}
