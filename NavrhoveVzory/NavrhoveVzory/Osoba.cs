using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory
{
    internal class Osoba
    {

        protected int Age { get; private set; }
        protected int Gender { get; private set; } //0 muz, 1 zena
        protected string Name { get; private set; }
        protected Osoba(int age, int gender, string name)
        {
            Age = age;
            Gender = gender;
            Name = name;
        }

        static public Osoba GetInstance(int age, int g, string n)
        {
            if(age < 0)
            {
                return null;
            }
            else if(age > 0 && age <= 7)
            {
                return Predskolak.getInstance(age, g, n);    
            }
            else if (age >= 8 && age <= 19)
            {
                return Skolak.getInstance(age, g, n);
            }
            else if (age >= 20 && age <= 65)
            {
                return Pracujici.getInstance(age, g, n);
            }
            else
            {
                return new Duchodce(age, g, n);
            }
        }
        public Osoba Old(int a)
        {
            var b = GetInstance(this.Age + a, this.Gender, this.Name);
            return b;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Gender: {Gender}";
        }
    }
}
