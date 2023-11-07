using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory
{
    internal class Predskolak : Osoba
    {
        private static Predskolak instance { get; set; }
        private Predskolak(int age, int gender, string name) : base(age, gender, name)
        {
        }
        public static Predskolak getInstance(int age, int g, string n)
        {
            if (instance == null)
            {
                instance = new Predskolak(age, g, n);
            }
            return instance;
        }
        public override string ToString()
        {
            return $"Predskolak, Name: {Name}, Age: {Age}, Gender: {Gender}";
        }
    }
}
