using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Abstractions
{
   public interface IClassroomRepository : IRepository<Classroom>
    {
        Classroom GetClassroomById(Guid classroomId);
    }
}
