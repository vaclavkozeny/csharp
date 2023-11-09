using System;
using System.ComponentModel;

namespace Dedeicnost05112020
{
    class Program
    {
        static void Main(string[] args)
        {
            Student kozeny = new Student("Václav", "Kožený");
            Student andrasko = new Student("Matěj", "Andráško", "X1");
            Human noone = new Teacher("Míchal", "Stehlík");
            Teacher stehlik = new Teacher("Míchal", "Stehlík");
            //Console.WriteLine(kozeny.FullName);
            //Console.WriteLine(andrasko.FullName);
            //Console.WriteLine(kozeny.Height);
            //Console.WriteLine(andrasko.Height);
            //Console.WriteLine(stehlik);
            //Console.WriteLine(noone);
            //stehlik.Metoda();
            //noone.Metoda();
            Human[] lidi = new Human[3];
            lidi[0] = kozeny;
            lidi[1] = stehlik;
            lidi[2] = noone;
            
            // vypíše ze seznamu lidi
            foreach(Human l in lidi)
            {
                l.Metoda();
            }

            // dedicnost
            // zapouzdreni
            // polymorfismus (polovina)
        }
        // můžu mít více konsruktorů a on si sám vybere podle zadaných parametrů
        // zdedění z třídy je pomocí :base(vlastontim od predka)
        // potomek rozsiruje tridu
        // potomek muze modifikovat puvodni vlastnosti
        // kazda trida je odvozena od OBJECT
        // vlastnosti se muzou rozsirovat
        // virtula a override jsou vlastnosti pro předka a potomka

        // abstraktní třída - nelze tvořit intsnce / slouží jako předek
    }
}
