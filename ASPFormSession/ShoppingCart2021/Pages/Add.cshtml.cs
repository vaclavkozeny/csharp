using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart2021.Models;
using ShoppingCart2021.Services;

namespace ShoppingCart2021.Pages
{
    public class AddModel : PageModel
    {
        [TempData]
        public string SuccessMessage { get; set; } // pro zprávu o úspìchu
        private ISessionStorage<List<CartItem>> _ss;

        

        public AddModel(ISessionStorage<List<CartItem>> ss)
        {
            _ss = ss;


        }
        public CartItem Item { get; set; }
        public void OnGet()
        {
            Item = new CartItem();
            Item.Name = "Sušenka";
            Item.Amount = 1;
            Item.UnitPrice = 9.90;
        }
        public ActionResult OnPost(CartItem Item)
        {
            if (!ModelState.IsValid) // je formuláø validní?
            {
                return Page(); // zobraz stránku, která patøí k tomuto PageModelu, tedy znovu formuláø
            }
            var list = _ss.LoadOrCreate("cart");
            list.Add(Item);
            _ss.Save("cart", list);
            Console.WriteLine(list.ToString());
            SuccessMessage = "Akce se podaøila.";
            return RedirectToPage("Index");
        }
    }
}
