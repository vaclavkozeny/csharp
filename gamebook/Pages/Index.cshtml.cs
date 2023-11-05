using GameBook.Interfaces;
using GameBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBook.Pages
{
    public class IndexModel : PageModel
    {
        private const string KEY = "GAMEBOOKKEY";

        private ISessionStorage<GameState> _ss;
        public GameState State { get; set; }
        public IndexModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;
        }
        public void OnGet()
        {
            State = _ss.LoadOrCreate(KEY);
            State.HP = 5;
            State.Mana = 10;
            State.Stamina = 10;
            State.Coins = 0;
            State.DMGMX = 1;
            State.MGMX = 1;
            State.FireStone = false;
            State.FireStoneCount = 0;
            State.WaterStone = false;
            State.WaterStoneCount = 0;
            State.EarthStone = false;
            State.EarthStoneCount = 0;
            State.GreenStone = false;
            State.GreenStoneCount = 0;
            _ss.Save(KEY, State);
        }

        // test
    }
}
