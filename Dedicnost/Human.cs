using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Dedeicnost05112020
{
    abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = 150;
            _id = 1;
        }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int Height { get; set; }
        public string FullName { get { return (FirstName + " " + LastName + _id); } }
        protected int _id; // chráněné - lze dědit, ale není přístupná na venek
        public override string ToString() // formát výpisu
        {
            return (FirstName + " " + LastName + _id);
        }

        // volá se podle deklarace
        public virtual void Metoda() // překrytelná metody
        {
            Console.WriteLine("Human");
        }

    }
}
