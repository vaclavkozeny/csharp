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
    public class WinModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;
        public GameState State { get; private set; }

        public WinModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;

        }



        public IActionResult OnGet(Room id)
        {
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            if(State.FireStone && State.WaterStone && State.EarthStone && State.GreenStone)
            {
                _ss.Save(KEY, State);
                return Page();

            }
            else
            {
                _ss.Save(KEY, State);
                return RedirectToPage("Place", new { id = id });
            }
        }
    }
}
