using GameBook.Exceptions;
using GameBook.Interfaces;
using GameBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBook.Services
{
    public class LocationProvider : ILocationProvider
    {
        private readonly List<Location> _locations = new List<Location>
        {
            new Location { Title="Start", Description="<p>Tvoje cesta začíná</p>" }, // 0
            new Location { Title="Vesnice", Description="<p>Vesnice vypadá obyčejně, ale něco se tu určitě najde</p>" }, // 1
            new Location { Title="Kostel", Description="<p>Stojíš v prázdném kostele</p>" }, // 2
            new Location { Title="Hospoda", Description="<p>Hospoda, zde si můžeš doplnit životy</p>" }, //3
            new Location { Title="Aréna", Description="<p>Aréna, zde můžeš bojovat a získat peníze</p>" }, //4
            new Location { Title="Obchod", Description="<p>Zde můžeš vylepšovat vybavení</p>" }, //5
            new Location { Title="Strom", Description="<p>Magický strom</p>" }, //6
            new Location { Title="Sopka", Description="<p>Sopka</p>" }, //7
            new Location { Title="Trhlina", Description="<p>Trhlina, na dně něco je</p>" }, //8
            new Location { Title="Mesto", Description="<p>Královské město</p>" }, //8
            new Location { Title="Jezero", Description="<p>Veliké jezero</p>" }, //8
            new Location { Title="Les", Description="<p>Hustý les</p>" }, //8


        };

        private readonly List<Connection> _map = new List<Connection>
        {
            //Start
            new Connection { From = Room.Start, Target = Room.Village, Description = "<p>Jít do vesnice</p>"},
            //Village
            new Connection { From = Room.Village, Target =  Room.Church, Description = "<p>Jít do kostela</p>"},
            new Connection { From = Room.Village, Target =  Room.Pub, Description = "<p>Jít do hospody</p>"},
            new Connection { From = Room.Village, Target =  Room.Arena, Description = "<p>Jít do arény</p>", TargetSpecialPage = "Village"},
            new Connection { From = Room.Village, Target =  Room.Tree, Description = "<p>Za vesnicí stojí opušťený strom</p>"},
            new Connection { From = Room.Village, Target =  Room.Forest, Description = "<p>Prohledat les</p>", TargetSpecialPage = "GreenStoneFight"},
            // Village special
            new Connection { From = Room.Village, Target = Room.Village, Description = "<p>Prohledat opuštěný dům</p>", TargetSpecialPage = "MinusHP"},
            //Church
            new Connection { From = Room.Church, Target = Room.Village, Description = "<p>Zpět do vesnice</p>"},
            //Church special
            //new Connection { From = Room.Church, Target = Room.Church, Description = "<p>Sebrat minci</p>", TargetSpecialPage = "PlusCoin"},
            //Pub
            new Connection { From = Room.Pub, Target = Room.Pub, Description = "<p>Dát si pivo (-1 Coin)</p>", TargetSpecialPage = "Drink"},
            //Pub special
            new Connection { From = Room.Pub, Target = Room.Village, Description = "<p>Jít zpět</p>"},
            //Tree
            new Connection { From = Room.Tree, Target = Room.Ravine, Description = "<p>Jít v rokli</p>", TargetSpecialPage = "EarthStoneFight"},
            new Connection { From = Room.Tree, Target = Room.City, Description = "<p>Jít do města</p>"},
            new Connection { From = Room.Tree, Target = Room.Lake, Description = "<p>Jít k jezeru</p>", TargetSpecialPage = "WaterStoneFight"},
            new Connection { From = Room.Tree, Target = Room.Vulcano, Description = "<p>Jít k sopce</p>", TargetSpecialPage = "FireStoneFight"},
            new Connection { From = Room.Tree, Target = Room.Tree, Description = "<p>Doplnit namu (-5 Coin)</p>", TargetSpecialPage = "ManaRefill"},
            new Connection { From = Room.Tree, Target = Room.Village, Description = "<p>Jít do vesnice</p>", TargetSpecialPage = "ManaRefill"},
          
            //City
            new Connection { From = Room.City, Target = Room.Store, Description = "<p>Jít do obchodu</p>"},
            new Connection { From = Room.Store, Target = Room.City, Description = "<p>Jít zpět</p>"},
            new Connection { From = Room.City, Target = Room.City, Description = "<p>Jít za králem</p>", TargetSpecialPage = "Win"},
            new Connection { From = Room.City, Target = Room.Tree, Description = "<p>Jít ke stromu</p>", TargetSpecialPage = "Win"},
            // Obchod nakupy
            new Connection { From = Room.Store, Target = Room.Store, Description = "<p>Vylepši útok (-2 Coin)</p>", TargetSpecialPage = "StoreDMGUP"},
            new Connection { From = Room.Store, Target = Room.Store, Description = "<p>Vylepši magii (-5 Coin)</p>", TargetSpecialPage = "StoreMGUP"},
            //new Connection { From = Room.Store, Target = Room.Store, Description = "<p>Koupit Rolls-Royce (-50 Coin)</p>", TargetSpecialPage = "EasterEgg"},

        };

        public bool ExistsLocation(Room id)
        {
            return _locations.Count > (int)id;
        }

        public List<Connection> GetConnectionsFrom(Room id, List<Connection> visitedConnections = null)
        {
            if (visitedConnections == null)
            {
                visitedConnections = new List<Connection>();
            }
            if (ExistsLocation(id))
            {
                return _map.Where(c => c.From == id && !visitedConnections.Contains(c)).ToList();
            }
            throw new InvalidLocationException();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            if (ExistsLocation(id))
            {
                return _map.Where(c => c.Target == id).ToList();
            }
            throw new InvalidLocationException();
        }

        public Location GetLocation(Room id)
        {
            if (ExistsLocation(id))
            {
                return _locations[(int)id];
            }
            throw new InvalidLocationException();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
