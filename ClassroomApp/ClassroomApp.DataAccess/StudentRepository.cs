using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomApp.DataAccess
{
   public class StudentRepository: BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ClassroomAppDbContext dbContext): base(dbContext)
        {

        }

        public Student GetStudentById(Guid studentId)
        {
            var oneStudent = dbContext.Students.Where(p => p.Id == studentId).SingleOrDefault();
            return oneStudent;
        }

        public Student GetStudentByName(string studentName)
        {
            var oneStudent = dbContext.Students.Where(p => p.Name == studentName).SingleOrDefault();
            return oneStudent;
        }
    }
}
