using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    public class ViewPublicGalleryModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        private readonly ILogger<ViewPublicGalleryModel> _logger;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public string userId { get; set; }
        //public List<StoredFileListViewModel> Files { get; set; } = new List<StoredFileListViewModel>();

        public List<StoredFileGallery> FilesDB { get; set; } = new List<StoredFileGallery>();
        public ViewPublicGalleryModel(ILogger<ViewPublicGalleryModel> logger, IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        public IActionResult OnGet(int gallid)
        {
            userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            FilesDB = _db.FilesGallery.Include(t => t.StoredFile).Include(g=>g.Gallery).Where(t=>t.GalleryId == gallid).ToList();
            return Page();
        }
       
        public IActionResult OnGetDownload(Guid id)
        {
            var fullName = Path.Combine(_environment.ContentRootPath, "Uploads", id.ToString());
            if (System.IO.File.Exists(fullName)) // existuje soubor na disku?
            {
                var fileRecord = _db.Files.Find(Guid.Parse(id.ToString()));
                if (fileRecord != null) // je soubor v datab·zi?
                {
                    return PhysicalFile(fullName, fileRecord.ContentType, fileRecord.OriginalName);
                    // vraù ho zp·tky pod p˘vodnÌm n·zvem a typem
                }
                else
                {
                    ErrorMessage = "There is no record of such file.";
                    return RedirectToPage();
                }
            }
            else
            {
                ErrorMessage = "There is no such file.";
                return RedirectToPage();
            }
        }
    }
}

