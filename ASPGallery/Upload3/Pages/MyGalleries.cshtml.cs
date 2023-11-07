using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    [Authorize]
    public class MyGalleriesModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public IList<Gallery> Galleries { get; set; }
        public MyGalleriesModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        public void OnGet()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            
            Galleries = _db.Galleries.Where(t => t.OwnerId == userId && t.IsDefault == false).ToList();
        }
        public  IActionResult OnGetThumbnail(int id)
        {
            var thum =  _db.Galleries.Where(t=>t.Id == id).FirstOrDefault();
            return File(thum.Blod, "image/jpeg");
        }
        public IActionResult OnPostPublish(int id)
        {
            var gallery = _db.Galleries.Where(t => t.Id == id).FirstOrDefault();
            var file = _db.FilesGallery.Include(g => g.StoredFile).Where(t => t.Gallery.Id == id).ToList();
            if (gallery.IsPublic)
            {
                gallery.IsPublic = false;
                foreach (var item in file)
                {
                    item.StoredFile.Published = false;
                }

            }
            else
            {
                gallery.IsPublic = true;
                foreach (var item in file)
                {
                    item.StoredFile.Published = true;
                }
            }

            _db.SaveChanges();
            return RedirectToPage("MyGalleries");

        }
    }
}
