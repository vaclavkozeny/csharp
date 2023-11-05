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
    public class HealModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;

        public GameState State { get; set; }

        public HealModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;

        }
        public IActionResult OnGet(Room id)
        {
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            if(State.Coins > 0)
            {
                State.Coins--;
                State.HP++;
            }
            _ss.Save(KEY, State);
            return RedirectToPage("Place", new { id = id }); // dodelat stranku kde ti rekne co se stalo + button zpet
        }
    }
}
