using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
   public class Request
    {
        public Guid Id { get; set; }
        public Classroom classroom { get; set; }
        public Student student { get; set; }
        public bool Confirmation { get; set; }
    }
}
