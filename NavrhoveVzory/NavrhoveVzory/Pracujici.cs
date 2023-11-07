using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory
{
    internal class Pracujici : Osoba
    {
        private static List<Pracujici> instances = new List<Pracujici>();
        public Pracujici(int age, int gender, string name) : base(age, gender, name)
        {
        }
        public static Pracujici getInstance(int age, int g, string n)
        {
            Pracujici pracujici;
            pracujici = new Pracujici(age, g, n);
            foreach (var a in instances)
            {
                if(a.Name == pracujici.Name && a.Age == pracujici.Age && a.Gender == pracujici.Gender)
                {
                    return a;
                }
            }
            instances.Add(pracujici);
            return pracujici;

        }
        public override string ToString()
        {
            return $"Pracujici, Name: {Name}, Age: {Age}, Gender: {Gender}, Pocet: {instances.Count}";
        }
    }
}
