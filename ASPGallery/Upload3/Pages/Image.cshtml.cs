using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using Upload3.Data;

namespace Upload3.Pages
{
    [Authorize]
    public class ImageModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        private readonly ILogger<ImageModel> _logger;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
       


        public Guid image { get; set; }
        public ImageModel(ILogger<ImageModel> logger, IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }
        public IActionResult OnGet(Guid id)
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var images = _db.Files.Where(f => f.Id == id).FirstOrDefault();
            if(images != null)
            {
                if (images.Published == true)
                {
                    image = id;
                    return Page();
                }
                else if (images.UploaderId != userId)
                {
                    ErrorMessage = "Not your image";
                    return RedirectToPage("Index");
                }
                else
                {
                    image = id;
                    return Page();
                }
            }
            else
            {
                ErrorMessage = "This picture doesn't exist";
                return RedirectToPage("Index");
            }
            
            
            
        }
    }
}
