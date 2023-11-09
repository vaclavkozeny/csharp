using System;
using System.Collections.Generic;

namespace cviceni2021114
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string> // určitě neobsahuje metody IsCountEven(), Even(), ShorterThen(int)
            {
                "Anna",
                "Bonifác",
                "Cecílie",
                "Daniel",
                "Ervin",
                "Flora",
                "Gabriel",
                "Herbert"
            };
            Console.WriteLine(Extension.IsCountEven(strings));
            Console.WriteLine(strings.IsCountEven());
            foreach(var item in strings.ShorterThen(4))
            {
                Console.WriteLine(item);
            }
        }
    }
}
