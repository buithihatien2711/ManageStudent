using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerStudent.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne<Faculty>(s => s.Faculty)             
                        .WithMany(f => f.Students)          
                        .HasForeignKey(s => s.FacultyID);

            base.OnModelCreating(modelBuilder);
        }
    }
}

// Fluent API
// modelBuilder.Entity<Student>(): bắt đầu thực thể Student
// HasOne<Faculty>(s => s.Faculty): xác định rằng thực thể Student có một thuộc tính kiểu Faculty
// Cấu hình đầu kia của mối quan hệ: .WithMany(f => f.Students) xác định rằng thực thể Faculty có nhiều thực thể Student
// .HasForeignKey(s => s.FacultyID): Chỉ định thuộc tính khóa ngoại là FacultyID
