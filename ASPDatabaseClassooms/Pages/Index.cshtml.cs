using Database2.Data;
using Database2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AppDbContext _db;
        public List<Classroom> Classrooms { get; set; }
        public List<Student> Students { get; set; }
        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            Classrooms = _db.Classrooms.OrderBy(c => c.Name).ToList();
            Students = _db.Students.OrderBy(c => c.Classroom).ToList();
        }
    }
}
