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
    public class MinusHPModel : PageModel
    {
        private Random rand = new Random();
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;
        public int HPLost { get; set; }
        public GameState State { get; set; }

        public MinusHPModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;

        }
        public IActionResult OnGet(Room id)
        {
            HPLost = rand.Next(1, 3);
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            
            for(int i = 0; i < HPLost; i++)
            {
                State.HP--;
                if (State.HP <= 0)
                {
                    return RedirectToPage("GameOver");
                }
            }
            
            _ss.Save(KEY, State);
            return RedirectToPage("Place", new { id = id });
        }
    }
}
