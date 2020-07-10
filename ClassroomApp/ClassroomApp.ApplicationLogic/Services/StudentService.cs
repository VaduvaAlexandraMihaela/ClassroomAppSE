using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Services
{
   public class StudentService
    {
        IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student GetStudentById(Guid studentId)
        {
            if (studentId == null)

            {

                throw new Exception("Null student id");

            }

            return studentRepository.GetStudentById(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {

            return studentRepository.GetAll();

        }

        public void AddStudent(string Name, string Email)
        {
            studentRepository.Add(new Student()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Email = Email, 
            });
        }
    }
}
