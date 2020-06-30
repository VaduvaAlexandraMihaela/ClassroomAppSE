using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomApp.DataAccess
{
   public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ClassroomAppDbContext dbContext) : base(dbContext)
        {

        }

        public Teacher GetTeacherById(Guid teacherId)
        {
            var oneTeacher = dbContext.Teachers.Where(p => p.Id == teacherId).SingleOrDefault();
            return oneTeacher;
        }
    }
}
