using ClassroomApp.ApplicationLogic.Data;
using ClassroomApp.ApplicationLogic.Services;
using ClassroomApp.Models.ClassroomModel;
using ClassroomApp.Models.GroupModel;
using ClassroomApp.Models.StudentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;
        private readonly ClassroomService classroomService;
        private readonly GroupService groupService;
        private readonly StudentService studentService;

        public TeacherController(TeacherService teacherService, ClassroomService classroomService, GroupService groupService, StudentService studentService)
        {
            this.teacherService = teacherService;
            this.classroomService = classroomService;
            this.groupService = groupService;
            this.studentService = studentService;
        }

        public ActionResult ViewClassrooms()
        {
            try

            {

                var classrooms = classroomService.GetAllClassrooms();



                return View(new GetAllClassroomsViewModel { Classrooms = classrooms });

            }

            catch (Exception)

            {

                return BadRequest("Invalid request received");

            }
        }

        public ActionResult ViewStudents()
        {
            try
            {
                var students = studentService.GetAllStudents();

                return View(new GetAllStudentsViewModel { Students = students });
            }
            catch(Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        [HttpGet]
        public IActionResult AddClassroom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClassroom([FromForm]AddClassroomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            teacherService.AddClassroom(model.Name);

            return Redirect(Url.Action("ViewClassrooms", "Teacher"));
        }

        [HttpGet]
        public IActionResult DeleteClassroom([FromRoute]Guid id)
        {

            var deleteVM = new DeleteClassroomViewModel { Id = id, Name = classroomService.GetClassroomName(id) };

            return View(deleteVM);

        }

        [HttpPost]
        public IActionResult DeleteClassroom(DeleteClassroomViewModel delVM)

        {

            teacherService.DeleteClassroom(delVM.Id);

            return Redirect(Url.Action("ViewClassrooms", "Teacher"));

        }

        [HttpGet]
        public IActionResult AddClassroomToGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClassroomToGroup(AddClassroomToGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            teacherService.AddClassroomstoGroup(model.classroomName, model.groupName);
            return Redirect(Url.Action("ViewGroups","Teacher"));
        }

        [HttpGet]
        public IActionResult AddStudentToClassroom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudentToClassroom(AddStudentToClassroomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            teacherService.AddStudentsToClassroom(model.studentName, model.classroomName);
            return Redirect(Url.Action("ViewClassrooms", "Teacher"));
        }

        public IActionResult ViewClassroomStudents(Guid Id)
        {
            try
            {
                var classroom = classroomService.GetClassroomById(Id);
                ICollection<Student> students = new List<Student>();
                students = classroom.Students;
                return View(new ClassroomStudentsViewModel { Students = students });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        public ActionResult ViewGroups()
        {
            try

            {

                var groups = teacherService.GetAllGroups();



                return View(new GetAllGroupsViewModel { Groups = groups });

            }

            catch (Exception)

            {

                return BadRequest("Invalid request received");

            }
        }

        [HttpGet]
        public IActionResult AddGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGroup([FromForm]AddGroupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            teacherService.AddGroup(model.Name);

            return Redirect(Url.Action("ViewGroups", "Teacher"));
        }
    }

   
}
