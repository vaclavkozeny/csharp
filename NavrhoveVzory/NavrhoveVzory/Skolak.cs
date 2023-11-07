using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory
{
    internal class Skolak : Osoba
    {
        private static int MAX_VALUE = 10;
        private static List<Skolak> instances = new List<Skolak>();
        private Skolak(int age, int gender, string name) : base(age, gender, name)
        {
        }
        public static Skolak getInstance(int age, int g, string n)
        {
            Skolak skolak;
            skolak = new Skolak(age, g, n);
            if (instances.Count < MAX_VALUE)
            {
                instances.Add(skolak);
            }
            return skolak;

        }
        public override string ToString()
        {
            return $"Skolak, Name: {Name}, Age: {Age}, Gender: {Gender}, Pocet: {instances.Count}";
        }
    }
}
