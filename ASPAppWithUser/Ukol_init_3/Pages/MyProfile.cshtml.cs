using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages
{
    [Authorize]
    public class MyProfileModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;

        public MyProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comments { get; set; }
        public ApplicationUser MyUser { get; set; }
        public IList<ForumThread> Threads { get; set; }

        public void OnGet( )
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            Comments = _context.Comments.Where(t => t.User.Id == userId).Include(t => t.Thread).ToList();
            MyUser = _context.Users.Where(User => User.Id == userId).FirstOrDefault();
            Threads = _context.Threads.Where(t => t.User.Id == userId).ToList();
        }
    }
}
