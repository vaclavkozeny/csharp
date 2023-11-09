using esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
           
                Console.WriteLine(" \n 1. Seřaďte data podle názvu a vypište je");
            var c1 = db.Countries
                .OrderBy(c => c.Name)
                .ToList();
            foreach (var t in c1) { Console.WriteLine(t.Name); }
        }
    }
}
