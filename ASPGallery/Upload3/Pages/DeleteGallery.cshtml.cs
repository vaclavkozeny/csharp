using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    public class DeleteGalleryModel : PageModel
    {
        private readonly Upload3.Data.ApplicationDbContext _context;
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public DeleteGalleryModel(Upload3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gallery Gallery { get; set; }

        public  IActionResult OnGetAsync(int? id)
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            if (id == null)
            {
                ErrorMessage = "Not found";
                return RedirectToPage("MyGalleries");
            }
            Gallery = _context.Galleries.Find(id);
            if (Gallery == null)
            {
                ErrorMessage = "Not found";
                return RedirectToPage("MyGalleries");
            }
            if (Gallery.OwnerId != userId)
            {
                ErrorMessage = "Not your gallery";
                return RedirectToPage("Index");
            }
            else
            {
                _context.Galleries.Remove(Gallery);
                _context.SaveChanges();
            }
            SuccessMessage = "Deleted";
            return RedirectToPage("./MyGalleries");
        }

        
    }
}
