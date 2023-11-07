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
    public class IndexThreadsModel : PageModel
    {
        private readonly Ukol_init_3.Data.ApplicationDbContext _context;

        public IndexThreadsModel(Ukol_init_3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ForumThread> ForumThread { get;set; }

        public async Task OnGetAsync()
        {
            ForumThread = await _context.Threads.ToListAsync();
        }
    }
}
