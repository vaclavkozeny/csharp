using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages
{
    [Authorize]
    public class AddCommentModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _um;
        [BindProperty]
        public int threadId { get; set; }
        public AddCommentModel(Ukol_init_3.Data.ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            _context = context;
            _um = um;
        }
        public ForumThread Forum { get; set; }
        public void OnGet(int threadid)
        {
            threadId = threadid;
            Forum = _context.Threads.Where(t => t.Id == threadId).FirstOrDefault();
        }

        [BindProperty]
        public Comment Comment { get; set; }
       

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            Comment.User = await _um.FindByIdAsync(userId);
            //Comment.Thread.Id = _threadId;
            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ThreadDetail", new { threadid = threadId });
        }
    }
}
