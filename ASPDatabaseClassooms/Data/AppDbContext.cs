using Database2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Classroom>().HasData(new Classroom { Id = 1 , Name = "P3"});
            mb.Entity<Classroom>().HasData(new Classroom { Id = 2, Name = "P4" });
            mb.Entity<Student>().HasData(new Student { Id = 2, Firstname = "Pepa" , Lastname ="Nocvak", ShoeSize = 55, ClassroomId = 1003});
            mb.Entity<Teacher>().HasData(new Teacher { Id = 1, Firstname = "Josef", Lastname = "Pospi"});
            mb.Entity<Teacher>().HasData(new Teacher { Id = 2, Firstname = "Andrej", Lastname = "Zeman" });
        }
    }
}
