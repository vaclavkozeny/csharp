using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBook.Interfaces;
using GameBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameBook.Pages
{
    public class PlusCoinModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;

        public GameState State { get; set; }

        public PlusCoinModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;


        }
        public IActionResult OnGet(Room id)
        {
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            State.Coins++;
            // Získaz connection z Location provider -> nová metoda? 
            /*Connection thisConnection = _lp.Where(c => c.Target == id && c.From == id && c.TargetSpecialPage == "PlusCoin" && c.OneTime);
            if(thisConnection != null)
            {
                State.VisitedConnections.Add(thisConnection);
            }*/
            _ss.Save(KEY, State);
            return RedirectToPage("Place", new { id = id });
        }
    }
}
