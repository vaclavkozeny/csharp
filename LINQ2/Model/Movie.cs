using System;
using System.Collections.Generic;
using System.Text;

namespace Extension.Model
{
    class Movie
    {
        public string Name { get; set; }
        public double Duration { get; set; }
        public override string ToString()
        {
            return Name + " " + Duration;
        }
    }
}
