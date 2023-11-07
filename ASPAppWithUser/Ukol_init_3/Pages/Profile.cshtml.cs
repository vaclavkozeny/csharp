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
    public class ProfileModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;

        public ProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comments { get; set; }
        public IList<ForumThread> Threads { get; set; }
        public ApplicationUser MyUser { get; set; }

        public void OnGet(string userId)
        {

            Comments = _context.Comments.Where(t => t.User.Id == userId).Include(t => t.Thread).ToList();
            MyUser = _context.Users.Where(User => User.Id == userId).FirstOrDefault();
            Threads = _context.Threads.Where(t => t.User.Id == userId).ToList();
        }
    }
}
