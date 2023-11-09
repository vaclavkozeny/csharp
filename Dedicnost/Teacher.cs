using System;
using System.Collections.Generic;
using System.Text;

namespace Dedeicnost05112020
{
    class Teacher : Human
    {
        public string Aprobation { get; set; }
        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {

        }
        // volá se podle deklarace

        /*public new string Metoda() // výpis odsud ne od předka
        {
            return "Teacher";
        }*/

        public override void Metoda() 
        {
            Console.WriteLine( "Teacher");
        }
        public override string ToString() // formát výpisu
        {
            return ("#######" + FirstName + " " + LastName + _id);
        }
    }
}
