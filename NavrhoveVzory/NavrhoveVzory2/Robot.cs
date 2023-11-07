using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavrhoveVzory2
{
    internal class Robot
    {
        private int CelkovyCas { get; set; }
        public Robot()
        {
        }

        public Modul modul { get; set; }
        public string AddModul(Modul modul)
        {
            this.modul = modul;
            return $"Robotovi byl přidán modul {this.modul}";
        }
        public void RemoveModul()
        {
            this.modul = null;
        }
        public void SwitchModul(Modul modul)
        {
            RemoveModul();
            AddModul(modul);
        }
        public string ProvedPozadavek(Povel povel)
        {
            if (modul != null)
            {
                //Console.WriteLine(modul);
                if (modul.getTyp() == povel.Cinnost)
                {
                    CelkovyCas += povel.Cas;
                    return $"Robot provedl činnost [{povel.Cinnost}], celkem pracoval [{CelkovyCas}]";
                }
                return $"Robot nemůže provést požadavek, nemá modul [{povel.Cinnost}]";
            }
            return "Neni modul";
        }
    }
}
