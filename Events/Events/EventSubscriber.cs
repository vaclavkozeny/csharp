using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class EventSubscriber
    {
        //siréna
        public void OnValueChanged(object sender, ExampleEventArgs e)
        {
            Console.WriteLine("Pozor HUUUUUUUUUUUUUUUUUUUUUUUU");
            //Console.WriteLine($"{sender.ToString()}");
        }
        public void OnValueOver(object sender, ExampleEventArgs e)
        {
            Console.WriteLine($"Je to přes limit {e.Value}");
        }
    }
}
