using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages
{
    [Authorize]
    public class AddThreadModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;
        private readonly ILogger<AddThreadModel> _logger;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _um;
        public AddThreadModel(ILogger<AddThreadModel> logger, Ukol_init_3.Data.ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            _logger = logger;
            _context = context;
            _um = um;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ForumThread Thread { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            Thread.User = await _um.FindByIdAsync(userId);
            _context.Threads.Add(Thread);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
