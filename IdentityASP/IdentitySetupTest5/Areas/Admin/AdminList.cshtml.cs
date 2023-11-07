using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySetupTest5.Areas.Admin
{
    public class AdminListModel : PageModel
    {

        private readonly ILogger<AdminListModel> _logger;
        private ApplicationDbContext _db;
        public List<ApplicationUser> Users { get; set; }
        //public List<Student> Students { get; set; }
        public AdminListModel(ILogger<AdminListModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public void OnGet()
        {
            Users = _db.Users.ToList();
        }
    }
}
