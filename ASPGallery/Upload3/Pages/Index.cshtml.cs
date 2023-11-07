using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {


        private IWebHostEnvironment _environment;
        private ApplicationDbContext _db;
        private readonly ILogger<IndexModel> _logger;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public List<StoredFileListViewModel> Files { get; set; } = new List<StoredFileListViewModel>();

        public List<StoredFile> FilesDB { get; set; } = new List<StoredFile>();
        public List<Gallery> Galleries { get; set; } = new List<Gallery>();
        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _db = db;
            _environment = environment;
            _logger = logger;
        }

        public void OnGet()
        {
            //var fullNames = Directory.GetFiles(Path.Combine(_environment.ContentRootPath, "Uploads")).ToList();
            /*foreach (var fn in fullNames)
            {
                Files.Add(Path.GetFileName(fn));
            }*/
            FilesDB = _db.Files.Where(t => t.Published == true).Take(12).ToList();
            Galleries = _db.Galleries.Include(f=>f.Owner).Where(g=>g.IsPublic == true).ToList();

            

        }

        public IActionResult OnGetDownload(Guid id)
        {
            var fullName = Path.Combine(_environment.ContentRootPath, "Uploads", id.ToString());
            if (System.IO.File.Exists(fullName)) // existuje soubor na disku?
            {
                var fileRecord = _db.Files.Find(Guid.Parse(id.ToString()));
                if (fileRecord != null) // je soubor v databázi?
                {
                    return PhysicalFile(fullName, fileRecord.ContentType, fileRecord.OriginalName);
                    // vrať ho zpátky pod původním názvem a typem
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
        public async Task<IActionResult> OnGetThumbnail(string filename, ThumbnailType type = ThumbnailType.Square)
        {
            StoredFile file = await _db.Files
              .AsNoTracking()
              .Where(f => f.Id == Guid.Parse(filename))
              .SingleOrDefaultAsync();
            if (file == null)
            {
                return NotFound("no record for this file");
            }
            Thumbnail thumbnail = await _db.Thumbnails
              .AsNoTracking()
              .Where(t => t.FileId == Guid.Parse(filename) && t.Type == type)
              .SingleOrDefaultAsync();
            if (thumbnail != null)
            {
                return File(thumbnail.Blob, file.ContentType);
            }
            return NotFound("no thumbnail for this file");
        }

    }
    public class StoredFileListViewModel
    {
        public Guid Id { get; set; }
        public IdentityUser Uploader { get; set; }
        public string UploaderId { get; set; }
        public DateTime UploadedAt { get; set; }
        public string OriginalName { get; set; }
        public string ContentType { get; set; }
        public int ThumbnailCount { get; set; }
    }
}
