﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBook.Interfaces;
using GameBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameBook.Pages
{
    public class ArenaModel : PageModel
    {
        private Random _rand = new Random();
        private const string KEY = "GAMEBOOKKEY";
        private ISessionStorage<GameState> _ss;
        public GameState State { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; } 

        public ArenaModel(ISessionStorage<GameState> ss)
        {
            _ss = ss;
            State = _ss.LoadOrCreate(KEY);
        }
        public ActionResult OnGet(string returnUrl)
        {
            if (returnUrl != "")
            {
                ReturnUrl = returnUrl;
            }
            if (State.CurrentEnemyHP == 0 && State.CurrentEnemyMX == 0)
            {
                State.CurrentEnemyHP = 5;
                State.CurrentEnemyMX = 1;
                State.CurrentEnemyImage = this._rand.Next(1, 5);
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
                    throw new Exception("Stamina pro útok musí být větší než 0");
                }
                State.CurrentEnemyHP -= 2 * State.DMGMX;
                State.Stamina--;

            }
            else if (type == 2)
            {
                if (State.Mana <= 1)
                {
                    throw new Exception("Mana pro útok musí být větší než 0");
                }
                State.CurrentEnemyHP -= 4 * State.MGMX;
                State.Mana -= 2;
            }
            else throw new Exception("Invalid operation");


            _ss.Save(KEY, State);
            if (State.CurrentEnemyHP <= 0) // Hráč vyhrál -> redirect na returnUrl
            {
                Console.WriteLine("Hráč vyhrál");
                State.CurrentEnemyHP = 0;
                State.CurrentEnemyMX = 0;
                State.Coins += 5;
                //State.FireStoneCount += 1;
                _ss.Save(KEY, State);
                return RedirectToPage("Place", new { id = ReturnUrl });
            }
            State.HP -= State.CurrentEnemyMX; // Udělat náhodně
            if (State.HP <= 0 || (State.Stamina <= 0 && State.Mana <= 1)) // Hráč prohrál -> redirect na GameOver
            {
                Console.WriteLine("Hráč prohrál");
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
