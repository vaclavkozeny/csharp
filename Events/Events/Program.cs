using System;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventPublisher pub = new EventPublisher();
            EventSubscriber sub = new EventSubscriber();
            pub.ValueHasChanged += sub.OnValueOver;
            pub.ValueHasChanged += ReportChange;
            //pub.ValueOver += sub.OnValueOver;
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine(i);
                pub.Value = i;
            }
            //pub.ValueHasChanged -= sub.OnValueChanged;
            
        }
        static void ReportChange(object sender, ExampleEventArgs e)
        {
            Console.WriteLine($"CinkCink {e.Value}");
        }
    }
}
