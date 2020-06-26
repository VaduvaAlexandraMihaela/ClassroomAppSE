using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Data
{
   public class Group
    {
        public Guid Id { get; set; }
        public Teacher teacher { get; set; }
        public string Name { get; set; }
    }
}
