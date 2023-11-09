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
        public string SuccessMessage { get; set; } // pro zpr�vu o �sp�chu
        private ISessionStorage<List<CartItem>> _ss;

        

        public AddModel(ISessionStorage<List<CartItem>> ss)
        {
            _ss = ss;


        }
        public CartItem Item { get; set; }
        public void OnGet()
        {
            Item = new CartItem();
            Item.Name = "Su�enka";
            Item.Amount = 1;
            Item.UnitPrice = 9.90;
        }
        public ActionResult OnPost(CartItem Item)
        {
            if (!ModelState.IsValid) // je formul�� validn�?
            {
                return Page(); // zobraz str�nku, kter� pat�� k tomuto PageModelu, tedy znovu formul��
            }
            var list = _ss.LoadOrCreate("cart");
            list.Add(Item);
            _ss.Save("cart", list);
            Console.WriteLine(list.ToString());
            SuccessMessage = "Akce se poda�ila.";
            return RedirectToPage("Index");
        }
    }
}
