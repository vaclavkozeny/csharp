using GameBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBook.Interfaces
{
    public interface ILocationProvider
    {
        bool ExistsLocation(Room id); // existuje na tomto indexu místnost?
        Location GetLocation(Room id); // získání dat místnosti na daném indexu
        List<Connection> GetConnectionsFrom(Room id, List<Connection> visitedConnections); // získání všech možnych cest z této místnosti
        List<Connection> GetConnectionsTo(Room id); // získání všech možných cest do této místnosti, bude použito při kontrole regulérnosti cesty
        bool IsNavigationLegitimate(Room from, Room to, GameState state); // test, zda byla cesta z jedné místnosti do druhé legitimní
                                                                        // rovnou přidejme i do kontroly i herní stav, možná by se mohl v pokročilejších implementacích hodit
    }
}
