using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory2
{
    internal class Ovladac
    {
        public Ovladac()
        {
        }
        public string PosliPozadavek(Povel p, Robot robot)
        {
            return $"Pozadavek [{p.Cinnost}] poslan na [{p.Misto}]. {robot.ProvedPozadavek(p)}";
        }
    }
}
