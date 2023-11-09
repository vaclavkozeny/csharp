using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShoppingCart2021.Models;
using ShoppingCart2021.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart2021.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [TempData]
        public string SuccessMessage { get; set; }
        public List<CartItem> Cart { get; set; } = new List<CartItem>();
        private ISessionStorage<List<CartItem>> _ss;
        public IndexModel(ILogger<IndexModel> logger, ISessionStorage<List<CartItem>> ss)
        {
            _logger = logger;
            _ss = ss;
        }

        public IActionResult OnGet()
        {
            Cart = _ss.LoadOrCreate("cart");
            return Page();
        }
        public void OnPost(int a)
        {
            Cart = _ss.LoadOrCreate("cart");
            Cart.RemoveAt(a);
            _ss.Save("cart", Cart);
        }
    }
}
