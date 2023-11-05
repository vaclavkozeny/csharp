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
    public class EasterEggModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;

        public GameState State { get; set; }
        public int Price { get; set; }
        public EasterEggModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;
            Price = 50; // asi zmenit

        }
        public ActionResult OnGet( )
        {
            State = _ss.LoadOrCreate(KEY);
            
            if (State.Coins > Price)
            {
                State.Coins = State.Coins - Price;
                _ss.Save(KEY, State);
            }
            else
            {
                return RedirectToPage("StoreLowMoney");
            }
            _ss.Save(KEY, State);
            return null;
        }
    }
}
