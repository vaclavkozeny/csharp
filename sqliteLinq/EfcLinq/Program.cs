using System.Linq;
using Microsoft.EntityFrameworkCore;

using EfcLinq.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfcLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            var c1 = db.Employees.Include(l => l.Location).OrderBy(c=>c.FirstName).ToList();
            foreach(var c in c1) { Console.WriteLine($"{c.FirstName} {c.EmployeeId} in {c.Location}"); }
            Console.WriteLine("----");
            var c2 = db.Employees
                .Include(l=>l.Location)
                .Where(c=>c.LocationId == 1)
                .ToList();
            var c22 = db.Locations
                .Where(c => c.LocationId == 1)
                .FirstOrDefault();
            Console.WriteLine(c22);
            foreach(var c in c2){ Console.WriteLine(c); }
            Console.WriteLine("----");
            var c3 = db.Locations
                .ToList();
            foreach (var c in c3) { Console.WriteLine($"{c.Name} has {c.Employees.Count()}"); }
            Console.WriteLine("----");
            var c4 = db.Employees.GroupBy((c => c.FirstName), (name, count) => new { name = name, count = count.Count()});
            foreach (var c in c4) { Console.WriteLine($"{c.name} is here {c.count}x"); }
           
        }
    }
} 
