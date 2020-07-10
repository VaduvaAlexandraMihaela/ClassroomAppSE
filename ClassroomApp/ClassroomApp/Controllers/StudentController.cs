using ClassroomApp.ApplicationLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomApp.Controllers
{
    public class StudentController: Controller
    {
        private readonly StudentService studentService; 

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }
        public ActionResult AddStudentsToClass()

        {

            return View();

        }
    }
}
