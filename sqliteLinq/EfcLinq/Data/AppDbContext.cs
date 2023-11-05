using EfcLinq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcLinq.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public AppDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            op.UseSqlite(@"Data Source=test.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Location>().HasData(new Location { LocationId = 1, Name = "Liberec" });
            mb.Entity<Location>().HasData(new Location { LocationId = 2, Name = "Jablonec" });
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 1, FirstName = "Adam", LocationId = 1});
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 2, FirstName = "Cyril", LocationId = 1 });
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 3, FirstName = "Bedřich", LocationId = 1 });
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 4, FirstName = "Adéla", LocationId = 2 });
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 5, FirstName = "Brunhylda", LocationId = 2 });
            mb.Entity<Employee>().HasData(new Employee { EmployeeId = 6, FirstName = "Cyril", LocationId = 2 });
        }
    }




    }

