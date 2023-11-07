using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySetupTest5.Pages
{
    [Authorize(Policy = "IsAdministrator")]
    public class AdminListPageModel : PageModel
    {
        private readonly ILogger<AdminListPageModel> _logger;
        private ApplicationDbContext _db;
        public List<ApplicationUser> Users { get; set; }
        public List<CoffeeCup> Coffees { get; set; }
        //public List<Student> Students { get; set; }
        public AdminListPageModel(ILogger<AdminListPageModel> logger, ApplicationDbContext db)
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
