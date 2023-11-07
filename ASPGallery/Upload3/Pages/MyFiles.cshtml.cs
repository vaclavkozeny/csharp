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
    public class MyFilesModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        private readonly ILogger<MyFilesModel> _logger;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public List<StoredFileListViewModel> Files { get; set; } = new List<StoredFileListViewModel>();

        public List<StoredFile> FilesDB { get; set; } = new List<StoredFile>();
        public MyFilesModel(ILogger<MyFilesModel> logger, IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        public void OnGet()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            FilesDB = _db.Files.Where(t => t.UploaderId == userId).ToList();
        }

        public IActionResult OnPostPublish(Guid id)
        {
            var file = _db.Files.Where(t => t.Id == id).First();
            if (file.Published)
            {
                file.Published = false;
            }
            else
            {
                file.Published = true;
            }

            _db.SaveChanges();
            return RedirectToPage("MyFiles");

        }
        public IActionResult OnGetSort(int id)
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            FilesDB = _db.Files.Where(t => t.UploaderId == userId).ToList();
            if (id == 1)
            {
                FilesDB = FilesDB.OrderByDescending(f => f.UploadedAt).ToList();
            }
            else if(id == 2)
            {
                FilesDB = FilesDB.OrderBy(t => t.OriginalName).ToList();
            }
            else if(id == 3)
            {
                FilesDB = FilesDB.OrderByDescending(t => t.Published).ToList();
            }
            return Page();
        }
        public IActionResult OnGetDelete(Guid id)
        {
            var fullName = Path.Combine(_environment.ContentRootPath, "Uploads", id.ToString());
            if (System.IO.File.Exists(fullName)) // existuje soubor na disku?
            {
                var fileRecord = _db.Files.Find(Guid.Parse(id.ToString()));
                if (fileRecord != null) // je soubor v datab·zi?
                {
                    _db.Files.Remove(fileRecord);
                    FileInfo file = new FileInfo(fullName);
                    file.Delete();
                    _db.SaveChanges();
                    SuccessMessage = "Deleted";
                    return RedirectToPage();
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
        public IActionResult OnGetImage(Guid id)
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
