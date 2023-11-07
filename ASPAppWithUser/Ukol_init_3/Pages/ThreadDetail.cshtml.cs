using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Ukol_init_3.Data;
using Ukol_init_3.Model;

namespace Ukol_init_3.Pages
{
    public class ThreadDetailModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public int _threadId { get; set; }

        public ThreadDetailModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Comment> Comments { get; set; }
        public IList<ApplicationUser> Users { get; set; }
        public ForumThread Forum { get; set; }

        public void OnGet(int threadid)
        {
            _threadId = threadid;
            Comments = _db.Comments.Where(t => t.ThreadId == _threadId).ToList();
            Forum = _db.Threads.Where(t => t.Id == _threadId).FirstOrDefault();
            Users = _db.Users.ToList();
        }
    }
}
