using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using System.Security.Claims;

namespace IdentitySetupTest5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IdentitySetupTest5.Data.ApplicationDbContext _context;

        public IndexModel(IdentitySetupTest5.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CoffeeCup> CoffeeCup { get;set; }
        
        public async Task OnGetAsync()
        {
           
            CoffeeCup = await _context.Cups.OrderByDescending(cc => cc.Created).ToListAsync();
        }
    }
}
