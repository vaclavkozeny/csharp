using IdentitySetupTest5.Data;
using IdentitySetupTest5.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySetupTest5.Pages
{
    public class CupsListDetailModel : PageModel
    {
        private readonly ILogger<CupsListDetailModel> _logger;
        private ApplicationDbContext _db;
        
        public List<CoffeeCup> Coffees { get; set; }
        //public List<Student> Students { get; set; }
        public CupsListDetailModel(ILogger<CupsListDetailModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public void OnGet(string id)
        {
            Coffees = _db.Cups.Where(t => t.UserId.Id == id).ToList();
        }
    }
}
