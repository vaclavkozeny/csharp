using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using IdentitySetupTest5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentitySetupTest5.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IdentitySetupTest5.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _um;

        public CreateModel(IdentitySetupTest5.Data.ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            _context = context;
            _um = um;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CoffeeCupIM Input { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            CoffeeCup cc = new CoffeeCup { MachineNo = Input.MachineNo, UserName = Input.UserName, Created = DateTime.Now};
            cc.UserId = await _um.FindByIdAsync(userId);
            _context.Cups.Add(cc);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
