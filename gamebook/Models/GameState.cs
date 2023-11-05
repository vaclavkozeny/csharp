using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBook.Models
{
    public class GameState
    {
        public int HP { get; set; } // počet životů postavy
        public Room Location { get; set; } // místnost, kde se postava nachází
        public int TrapTrigered { get; set; } // pocet aktivovanych pasti
        public int Mana { get; set; } // stav many
        public int Stamina { get; set; } // stav staminy
        public int Coins { get; set; } // pocet penez
        public int DMGMX { get; set; } // damage multiplexer
        public int MGMX { get; set; } // magic multiplexer
        public List<Connection> VisitedConnections { get; set; }
        public int CurrentEnemyHP { get; set; } // životy nepřítele, se kterým momentálně bojujem
        public int CurrentEnemyMX { get; set; } // damage
        public int CurrentEnemyImage { get; set; }

        // Sbirani kamenu pro konec hry
        public bool FireStone { get; set; }
        public int FireStoneCount { get; set; }
        public bool WaterStone { get; set; }
        public int WaterStoneCount { get; set; }
        public bool EarthStone { get; set; }
        public int EarthStoneCount { get; set; }
        public bool GreenStone { get; set; }
        public int GreenStoneCount { get; set; }
    }
}
