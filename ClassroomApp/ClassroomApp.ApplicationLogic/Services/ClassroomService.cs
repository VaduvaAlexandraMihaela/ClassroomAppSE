using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Services
{
   public class ClassroomService
    {
        IClassroomRepository classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
        }

        public Classroom GetClassroomById(Guid classroomId)
        {
            if (classroomId == null)

            {

                throw new Exception("Null classroom id");

            }

            return classroomRepository.GetClassroomById(classroomId);
        }

        public Classroom GetClassroomByName(string classroomName)
        {
            if(classroomName == null)
            {
                throw new Exception("Null classroom name");
            }

            return classroomRepository.GetClassroomByName(classroomName);
        }

        public IEnumerable<Classroom> GetAllClassrooms()
        {

            return classroomRepository.GetAll();

        }

        public string GetClassroomName(Guid id)

        {

            var classObj = classroomRepository.GetClassroomById(id);

            return classObj.Name;

        }
    }
}
