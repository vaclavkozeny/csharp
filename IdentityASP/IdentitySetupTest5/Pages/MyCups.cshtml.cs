using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IdentitySetupTest5.Pages
{
    [Authorize]
    public class MyCupsModel : PageModel
    {
        private readonly ILogger<MyCupsModel> _logger;
        private ApplicationDbContext _db;

        public List<CoffeeCup> Coffees { get; set; }
        //public List<Student> Students { get; set; }
        public MyCupsModel(ILogger<MyCupsModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public void OnGet()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            Coffees = _db.Cups.Where(t => t.UserId.Id == userId).ToList();
        }
    }
}
