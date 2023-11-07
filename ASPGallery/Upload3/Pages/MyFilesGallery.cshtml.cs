using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    [Authorize]
    public class MyFilesGalleryModel : PageModel
    {

        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        private readonly ILogger<MyFilesGalleryModel> _logger;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public int galleid { get; set; }

        public List<StoredFileGallery> FilesDB { get; set; } = new List<StoredFileGallery>();
        public MyFilesGalleryModel(ILogger<MyFilesGalleryModel> logger, IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        public IActionResult OnGet(int gallid)
        {
            galleid = gallid;
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            FilesDB = _db.FilesGallery.Include(t=>t.StoredFile).Where(t => t.GalleryId == gallid).ToList();
            var gall = _db.Galleries.Where(t=>t.Id == gallid).FirstOrDefault();
            if(gall.OwnerId == userId)
            {
                return Page();
            }
            else
            {
                ErrorMessage = "Not your gallery";
                return RedirectToPage("Index");
            }
            
        }
        public IActionResult OnGetDelete(Guid id, int galeryid)
        {
            var filetodel = _db.FilesGallery.Where(f=>f.StoredFileId == id && f.GalleryId == galeryid).FirstOrDefault();
            _db.FilesGallery.Remove(filetodel);
            _db.SaveChanges();
            SuccessMessage = "Deleted from gallery";
            return RedirectToPage("MyFilesGallery" , new {gallid = galeryid});
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

