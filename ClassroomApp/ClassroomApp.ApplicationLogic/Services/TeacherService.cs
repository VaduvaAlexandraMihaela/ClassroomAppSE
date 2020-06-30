using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Services
{
  public class TeacherService
    {
        ITeacherRepository teacherRepository;
        IClassroomRepository classroomRepository;
        IGroupRepository groupRepository;

       public TeacherService(ITeacherRepository teacherRepository, IClassroomRepository classroomRepository,
           IGroupRepository groupRepository)
        {
            this.teacherRepository = teacherRepository;
            this.classroomRepository = classroomRepository;
            this.groupRepository = groupRepository;
        }

        public Teacher GetTeacherById(Guid teacherId)
        {
            if (teacherId == null)

            {

                throw new Exception("Null project id");

            }
            return teacherRepository.GetTeacherById(teacherId);
        }

        public IEnumerable<Classroom> GetAllClassrooms()

        {

            return classroomRepository.GetAll();

        }

        public void AddClassroom(string Name)
        {
            classroomRepository.Add(new Classroom()
            {
                Id = Guid.NewGuid(),
                Name = Name
            });
        }

        public void AddGroup(string Name)
        {
            groupRepository.Add(new Group
            {
                Id = Guid.NewGuid(),
                Name = Name
            });
        }

        public void DeleteClassroom(Guid classroomId)

        {

            var oneClass = classroomRepository.GetClassroomById(classroomId);

            classroomRepository.Delete(oneClass);

        }

        public string GetClassroomName(Guid id)

        {

            var classObj = classroomRepository.GetClassroomById(id);

            return classObj.Name;

        }
    }
}
