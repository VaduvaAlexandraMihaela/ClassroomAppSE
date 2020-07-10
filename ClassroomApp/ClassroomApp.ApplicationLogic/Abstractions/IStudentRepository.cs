using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Abstractions
{
   public interface IStudentRepository: IRepository<Student>
    {
        Student GetStudentById(Guid studentId);
        Student GetStudentByName(string studentName);
    }
}
