using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using Upload3.Data;
using Upload3.Model;

namespace Upload3.Pages
{
    public class AddGalleryModel : PageModel
    {
        private readonly Upload3.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private int _squareSize;
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public string user { get; set; }
        [Display(Name = "Thumbnail")]
        [Required]
        public IFormFile Upload { get; set; }
        public AddGalleryModel(Upload3.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            if (Int32.TryParse(_configuration["Thumbnails:SquareSize"], out _squareSize) == false) _squareSize = 64; // získej data z konfigurave nebo použij 64

        }

        public void OnGet()
        {
            user = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value; // získáme id přihlášeného uživatele
        }

        [BindProperty]
        public Gallery Gallery { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           
            
                MemoryStream ims = new MemoryStream(); // proud pro příchozí obrázek
                MemoryStream oms1 = new MemoryStream(); // proud pro čtvercový náhled
                Upload.CopyTo(ims); // vlož obsah do vstupního proudu
                IImageFormat format; // zde si uložíme formát obrázku (JPEG, GIF, ...), budeme ho potřebovat při ukládání
            using (Image image = Image.Load(ims.ToArray(), out format)) // vytvoříme čtvercový náhled
            {
                int largestSize = Math.Max(image.Height, image.Width); // jaká je orientace obrázku?
                if (image.Width > 2000 || image.Height > 2000)
                {
                    ErrorMessage = "OOOPPPPSSSS image is too big";
                    return RedirectToPage("AddGallery");
                }

            }
            using (Image image = Image.Load(ims.ToArray(), out format)) // vytvoříme čtvercový náhled
                {
                    int largestSize = Math.Max(image.Height, image.Width); // jaká je orientace obrázku?
                    if (image.Width > image.Height) // podle orientace změníme velikost obrázku
                    {
                        image.Mutate(x => x.Resize(0, _squareSize));
                    }
                    else
                    {
                        image.Mutate(x => x.Resize(_squareSize, 0));
                    }
                    image.Mutate(x => x.Crop(new Rectangle((image.Width - _squareSize) / 2, (image.Height - _squareSize) / 2, _squareSize, _squareSize)));
                    // obrázek ořízneme na čtverec
                    image.Save(oms1, format); // vložíme ho do výstupního proudu
                    Gallery.Blod = oms1.ToArray();
                    //fileRecord.Thumbnails.Add(new Thumbnail { Type = ThumbnailType.Square, Blob = oms1.ToArray() }); // a uložíme do databáze jako pole bytů
                }
            
            
            if (!ModelState.IsValid)
            {
                ErrorMessage = "There was error while processing";
                return Page();
            }
            //var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value; // získáme id přihlášeného uživatele
            //var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            //Gallery.OwnerId = userId;
            _context.Galleries.Add(Gallery);
            await _context.SaveChangesAsync();
            SuccessMessage = "Added gallrey";
            return RedirectToPage("./MyGalleries");
        }
    }
}
