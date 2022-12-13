using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerStudent.Models;

namespace ManagerStudent.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
         
        Student? GetStudentById(int id);

        void CreateStudent(Student student);

        void DeleteStudent(int id);

        void UpdateStudent(Student student);

        List<Faculty> GetFaculties();
    }
}