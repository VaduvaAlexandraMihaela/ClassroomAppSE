using ClassroomApp.ApplicationLogic.Abstractions;
using ClassroomApp.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassroomApp.ApplicationLogic.Services
{
  public class TeacherService
    {
        ITeacherRepository teacherRepository;
        IClassroomRepository classroomRepository;
        IGroupRepository groupRepository;
        IStudentRepository studentRepository;
        IAssignmentRepository assignmentRepository;

       public TeacherService(ITeacherRepository teacherRepository, IClassroomRepository classroomRepository,
           IGroupRepository groupRepository, IStudentRepository studentRepository, IAssignmentRepository assignmentRepository)
        {
            this.teacherRepository = teacherRepository;
            this.classroomRepository = classroomRepository;
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
            this.assignmentRepository = assignmentRepository;
        }

        public Teacher GetTeacherById(Guid teacherId)
        {
            if (teacherId == null)

            {

                throw new Exception("Null teacher id");

            }
            return teacherRepository.GetTeacherById(teacherId);
        }

        public void AddTeacher(string Name, string Email)
        {
            teacherRepository.Add(new Teacher()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Email = Email,
            });
        }

        public void AddAssignment(string Description, DateTime deadline, Guid idClassroom)
        {
            var classroom = classroomRepository.GetClassroomById(idClassroom);

            assignmentRepository.Add(new Assignment()
            {
                Id = Guid.NewGuid(),
                classroom = classroom,
                Description = Description,
                Deadline = deadline
            });
        }

        public void AddClassroom(string Name)
        {
            classroomRepository.Add(new Classroom()
            {
                Id = Guid.NewGuid(),
                Name = Name, 
                Students = new List<Student>()
            });
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return groupRepository.GetAll();
        }

        public void AddGroup(string Name)
        {
           
            groupRepository.Add(new Group
            {
                Id = Guid.NewGuid(),
                Name = Name, 
                Classrooms = new Collection<Classroom>(),
            });
        }

        public void AddClassroomstoGroup(string classroomName, string groupName)
        {
            var classroom = classroomRepository.GetClassroomByName(classroomName);
            var group = groupRepository.GetGroupByName(groupName);
            if(group.Classrooms == null)
            {
                group.Classrooms = new List<Classroom>();
            }
            group.Classrooms.Add(classroom);
        }

        public void AddStudentsToClassroom(string studentName, string classroomName)
        {
            var classroom = classroomRepository.GetClassroomByName(classroomName);
            var student = studentRepository.GetStudentByName(studentName);
            if(classroom.Students == null)
            {
                classroom.Students = new List<Student>();
            }
            classroom.Students.Add(student);
        }

        public void DeleteClassroom(Guid classroomId)

        {

            var oneClass = classroomRepository.GetClassroomById(classroomId);

            classroomRepository.Delete(oneClass);

        }

      
    }
}
