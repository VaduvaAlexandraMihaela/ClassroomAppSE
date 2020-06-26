using ClassroomApp.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomApp.DataAccess
{
   public class ClassroomAppDbContext : DbContext
    {
        public ClassroomAppDbContext(DbContextOptions<ClassroomAppDbContext> options): base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Classroom> Classrooms { get; set; }

        public DbSet<Grading> Gradings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }

    }
}
