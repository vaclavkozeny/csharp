using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NavrhoveVzory2.Modul;

namespace NavrhoveVzory2
{
    internal class Povel
    {
        public Povel(Typ cinnost, int cas, string misto)
        {
            Cinnost = cinnost;
            Cas = cas;
            Misto = misto;
        }

        public Typ Cinnost { get; set; }
        public int Cas { get; set; }
        public string Misto { get; set; }
    }

}
