using ClassroomApp.ApplicationLogic.Services;
using ClassroomApp.Models.ClassroomModel;
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

        public TeacherController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        public ActionResult ViewClassrooms()
        {
            try

            {

                var classrooms = teacherService.GetAllClassrooms();



                return View(new GetAllClassroomsViewModel { Classrooms = classrooms });

            }

            catch (Exception)

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

            var deleteVM = new DeleteClassroomViewModel { Id = id, Name = teacherService.GetClassroomName(id) };

            return View(deleteVM);

        }

        [HttpPost]
        public IActionResult DeleteClassroom(DeleteClassroomViewModel delVM)

        {

            teacherService.DeleteClassroom(delVM.Id);

            return Redirect(Url.Action("ViewClassrooms", "Teacher"));

        }
    }

   
}
