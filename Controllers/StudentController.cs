using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerStudent.Models;
using ManagerStudent.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagerStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        public IActionResult Index()
        {
            var students =  _studentService.GetStudents();
            return View(students);
        }
        
        public IActionResult Create()
        {
            var faculties = _studentService.GetFaculties();
            return View(faculties);
        }

        public IActionResult Update(int id)
        {
            var student = _studentService.GetStudentById(id);
            if(student == null) return RedirectToAction("Create");

            var faculties = _studentService.GetFaculties();
            ViewBag.Student = student;
            return View(faculties);
        }

        public IActionResult Save(Student student)
        {
            if(student.Id == 0)
            {
                _studentService.CreateStudent(student);
            }
            else
            {
                _studentService.UpdateStudent(student);
            }
            return RedirectToAction("Index");
        } 

        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}