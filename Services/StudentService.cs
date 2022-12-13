using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerStudent.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            this._context = context;
        }

        public List<Faculty> GetFaculties()
        {
            return _context.Faculties.ToList();
        }

        public List<Student> GetStudents()
        {
            return _context.Students.Include(s => s.Faculty).ToList();
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var exist_student = GetStudentById(id);
            if(exist_student != null)
            {
                _context.Students.Remove(exist_student);
                _context.SaveChanges();
            }
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            var exist_student = GetStudentById(student.Id);
            if(exist_student != null)
            {
                exist_student.Name = student.Name;
                exist_student.Gender = student.Gender;
                exist_student.Faculty = student.Faculty;
                exist_student.FacultyID = student.FacultyID;
                _context.Students.Update(student);
                _context.SaveChanges();
            }
        }
    }
}