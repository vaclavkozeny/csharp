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
    public class StoreMGUPModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;

        public GameState State { get; set; }
        public int Price { get; set; }
        public StoreMGUPModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;
            Price = 5; // asi zmenit

        }
        public ActionResult OnGet(Room id)
        {
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            if (State.Coins > Price)
            {
                State.Coins = State.Coins - Price;
                State.MGMX++;
                _ss.Save(KEY, State);
            }
            else
            {
                return RedirectToPage("StoreLowMoney");
            }
            //_ss.Save(KEY, State);
            return RedirectToPage("Place", new { id = id });
        }
    }
}
