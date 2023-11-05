using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBook.Interfaces;
using GameBook.Models;
using GameBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameBook.Pages
{
    public class PlaceModel : PageModel
    {
        private Random _rand = new Random();
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;
        private ILocationProvider _lp;

        public Location Location { get; set; }
        public List<Connection> Connections { get; set; }
        public GameState State { get; set; }
        public int RandomFight { get; set; }

        public PlaceModel(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
        }
        

        public ActionResult OnGet(Room id)
        {
            RandomFight =  _rand.Next(100);
            if(RandomFight < 25)
            {
                RedirectToPage("RFight");
            }
            
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            
            if(State.HP <= 0)
            {
                return RedirectToPage("GameOver");
            }
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Connections = _lp.GetConnectionsFrom(id, State.VisitedConnections);
            //--------------------------------------
            return null;

        }
    }
}
