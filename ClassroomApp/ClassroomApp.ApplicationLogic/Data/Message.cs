using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
  public class Message
    {
        public Guid Id { get; set; }
        public Teacher teacher { get; set; }
        public Classroom classroom { get; set; }
        public string Text { get; set; }
    }
}
