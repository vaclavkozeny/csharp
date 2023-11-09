using System;
using System.Collections.Generic;
using System.Text;

namespace Dedeicnost05112020
{
    class Student : Human
    {
        public string Classroom { get; set; }

        // můžu mít více konsruktorů a on si sám vybere podle zadaných parametrů
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
            Classroom = "P2";
        }
        public Student(string firstName, string lastName, string classroom) : base(firstName, lastName)
        {
            Classroom = classroom;
        }


        /*public void SetProperties(string fn)
        {
            FirstName = fn;
        }*/


        // nastavnení poldle vstupů
        public void SetProperties(string fn, string ln = "Pokorný") // implicitní parametr ln
        {
            FirstName = fn;
            LastName = ln;
        }
        public void SetProperties(string fn, int h)
        {
            FirstName = fn; // nastaví jméno
            Height = h; // nastavý výšku
        }


        // výpsi typu
        public override void Metoda() 
        {
            Console.WriteLine("Student");
        }
        // formát výpisu
        public new string FullName { get { return (FirstName + " " + LastName + _id + " " + Classroom); } }
    }
}
