using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomApp.DataAccess
{
   public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(ClassroomAppDbContext dbContext) :base(dbContext)
        {

        }

        public Classroom GetClassroomById(Guid classroomId)
        {
            var oneClassroom = dbContext.Classrooms.Where(p => p.Id == classroomId).SingleOrDefault();
            return oneClassroom;
        }
    }
}
