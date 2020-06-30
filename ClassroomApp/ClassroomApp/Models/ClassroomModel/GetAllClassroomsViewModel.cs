using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApp.Models.ClassroomModel
{
    public class GetAllClassroomsViewModel
    {
        public IEnumerable<Classroom> Classrooms { get; set; }
    }
}
