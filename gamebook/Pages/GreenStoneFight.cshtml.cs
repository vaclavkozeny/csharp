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
    public class GreenStoneFightModel : PageModel
    {
        private Random _rand = new Random();
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;
        public GameState State { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        public GreenStoneFightModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;
            State = _ss.LoadOrCreate(KEY);
        }
        public ActionResult OnGet(string returnUrl)
        {
            if (State.GreenStone == true)
            {
                Console.WriteLine("Redirect to village");
                return RedirectToPage("Place", new { id = "Village" });
            }
            if (State.CurrentEnemyHP == 0 && State.CurrentEnemyMX == 0)
            {
                State.CurrentEnemyHP = 3;
                State.CurrentEnemyMX = 3;
                _ss.Save(KEY, State);
            }
            return Page();
        }

        public ActionResult OnPost(int type)
        {
            State = _ss.LoadOrCreate(KEY);

            if (type == 1)
            {
                if (State.Stamina <= 0)
                {
                    throw new Exception("Stamina pro �tok mus� b�t v�t�� ne� 0");
                }
                State.CurrentEnemyHP -= 2 * State.DMGMX;
                State.Stamina--;

            }
            else if (type == 2)
            {
                if (State.Mana <= 1)
                {
                    throw new Exception("Mana pro �tok mus� b�t v�t�� ne� 0");
                }
                State.CurrentEnemyHP -= 4 * State.MGMX;
                State.Mana -= 2;
            }
            else throw new Exception("Invalid operation");


            _ss.Save(KEY, State);
            if (State.CurrentEnemyHP <= 0) // Hr�� vyhr�l -> redirect na returnUrl
            {
                Console.WriteLine("Hr�� vyhr�l");
                State.CurrentEnemyHP = 0;
                State.CurrentEnemyMX = 0;
                //State.Coins += 5;
                State.GreenStoneCount += 1;
                State.GreenStone = true;
                _ss.Save(KEY, State);
                return RedirectToPage("Place", new { id = "Village" });
            }
            State.HP -= State.CurrentEnemyMX; // Ud�lat n�hodn�
            if (State.HP <= 0 || (State.Stamina <= 0 && State.Mana <= 1)) // Hr�� prohr�l -> redirect na GameOver
            {
                Console.WriteLine("Hr�� prohr�l");
                State.CurrentEnemyHP = 0;
                State.CurrentEnemyMX = 0;
                _ss.Save(KEY, State);
                return RedirectToPage("GameOver");
            }
            _ss.Save(KEY, State);
            return this.OnGet("");
        }
    }
}

