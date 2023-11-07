using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages.Admin
{
    [Authorize(Policy = "IsAdministrator")]
    public class EditThrModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;

        public EditThrModel(Ukol_init_3.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ForumThread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumThreadExists(ForumThread.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexThreads");
        }

        private bool ForumThreadExists(int id)
        {
            return _context.Threads.Any(e => e.Id == id);
        }
    }
}
