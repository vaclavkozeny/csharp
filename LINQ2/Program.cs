using Extension.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Extension
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             Extension
            .Where => urcení podminky kde neco je => filtrovani dat
            .OrderBy => seradi vzestuone pole podle urceneho parametru
            .OrderByDescending => seradí sestupne podle parametru
            .Select => muze zmenit datovy typ
            .GroupBy => seskupí objekty podle zadaneho parametru / vytvori jinou skupinu
            Razeni nahodne => .OrderBy(rand.Random())
             
             */


            Random rand = new Random();
            List<Movie> movies = new List<Movie>
            {
                new Movie{Name = "Alien", Duration = 1.5},
                new Movie{Name = "Alien 2", Duration = 2},
                new Movie{Name = "Frozen", Duration =1},
                new Movie{Name = "Terminator", Duration = 2}
            };


            /*foreach (var m in movies.Where(m => m.Duration > 1 && m.Name.StartsWith("Al")).OrderByDescending(m => m.Duration))
            {
                Console.WriteLine(m);
            }*/
            /*foreach (var m in movies.Select(m => (new Recodr { RecordName = m.Name , Number = 1})))
            {
                Console.WriteLine(m);
            }*/
            foreach (var m in movies.GroupBy(m => m.Duration).Where(x => x.Key > 1.3))
            {
                List<Movie> sel = new List<Movie>(m.ToList());
                Console.WriteLine(m.Key);
                foreach (var s in sel)
                {
                    Console.WriteLine(s.Name);
                }
            }
            foreach (var m in movies.OrderBy(m => rand.Next()))
            {
                Console.WriteLine(m);
            }
        }
    }
    class Recodr
    {
        public string RecordName { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return RecordName + " " + Number;
        }
    }
}
