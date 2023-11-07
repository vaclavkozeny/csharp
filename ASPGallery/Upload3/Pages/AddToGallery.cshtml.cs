using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    public class AddToGalleryModel : PageModel
    {
        private readonly Upload3.Data.ApplicationDbContext _context;
        public Guid getfileId { get; set; }
        public bool IfExist { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public AddToGalleryModel(Upload3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(Guid fileId)
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var test = _context.Galleries.Where(t => t.Owner.Id == userId && t.IsDefault == false).ToList();
            if(test.Count == 0)
            {
                ErrorMessage = "There is no gallery";
                return RedirectToPage("MyGalleries");
            }

            ViewData["GalleryId"] = new SelectList(test, "Id", "Name");
            getfileId = _context.Files.Where(t => t.Id == fileId).FirstOrDefault().Id;
            //ViewData["StoredFileId"] = new SelectList(_context.Files.Where(t=>t.Id == fileId), "Id", "OriginalName");
            return Page();
        }

        [BindProperty]
        public StoredFileGallery StoredFileGallery { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            IfExist = _context.FilesGallery.Contains(StoredFileGallery);
            if (IfExist)
            {
                ErrorMessage = "This picture is already in that gallery";
                return RedirectToPage("./MyFiles");
            }
            _context.FilesGallery.Add(StoredFileGallery);
            await _context.SaveChangesAsync();
            SuccessMessage = "Added to gallery";
            return RedirectToPage("./MyFiles");
        }
    }
}
