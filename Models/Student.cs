using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerStudent.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public bool Gender { get; set; }
        
        public int FacultyID { get; set; }
        
        public Faculty Faculty { get; set; }
    }
}