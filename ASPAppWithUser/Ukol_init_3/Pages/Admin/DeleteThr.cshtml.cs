using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages.Admin
{
    [Authorize(Policy = "IsAdministrator")]
    public class DeleteThrModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;

        public DeleteThrModel(Ukol_init_3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ForumThread ForumThread { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ForumThread = await _context.Threads.FirstOrDefaultAsync(m => m.Id == id);

            if (ForumThread == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ForumThread = await _context.Threads.FindAsync(id);

            if (ForumThread != null)
            {
                _context.Threads.Remove(ForumThread);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexThreads");
        }
    }
}
