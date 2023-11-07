using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory
{
    internal class Duchodce : Osoba
    {
        public Duchodce(int age, int gender, string name) : base(age, gender, name)
        {
        }
        public override string ToString()
        {
            return $"Duchodce, Name: {Name}, Age: {Age}, Gender: {Gender}";
        }
    }
}
