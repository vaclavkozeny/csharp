using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class EventPublisher
    {
        private int _value;
        //private int _lastvalue;
        //senzor
        public int Threshold { get; set; } = 10;
        public int Value 
        { 
            get
                { 
                    return _value; 
                } 
            set 
                {
                    
                    //if(ValueHasChanged != null) ValueHasChanged(this, new ExampleEventArgs(value));
                    //ValueHasChanged?.Invoke(this, new ExampleEventArgs(value));
                    if(value > Threshold) ValueHasChanged(this, new ExampleEventArgs(value));
                    _value = value;
                    
                } 
        }
        

        public event ExampleEventHandler ValueHasChanged;
        
    }
}
