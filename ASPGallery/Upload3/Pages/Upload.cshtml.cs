using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
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

    [Authorize]
    public class UploadModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private int _squareSize;
        private int _sameAspectRatioHeigth;
        //public Guid filetogalleryId { get; set; }
        public Gallery filetogallerygallery { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public ICollection<IFormFile> Upload { get; set; }
        public string userId { get; set; }

        public UploadModel(IWebHostEnvironment environment, ApplicationDbContext context, IConfiguration configuration)
        {
            _environment = environment;
            _context = context;
            _configuration = configuration;
            if (Int32.TryParse(_configuration["Thumbnails:SquareSize"], out _squareSize) == false) _squareSize = 64; // získej data z konfigurave nebo použij 64
            //if (Int32.TryParse(_configuration["Thumbnails:SameAspectRatioHeigth"], out _sameAspectRatioHeigth) == false) _sameAspectRatioHeigth = 1080;
        }
        public void OnGet()
        {
            userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            //return RedirectToPage("/Index");
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value; // získáme id pøihlášeného uživatele
            int successfulProcessing = 0;
            int failedProcessing = 0;
            foreach (var uploadedFile in Upload) // pro každý nahrávaný soubor
            {
                if (uploadedFile.ContentType.StartsWith("image"))
                {

                    var fileRecord = new StoredFile // vytvoøíme záznam
                    {
                        OriginalName = uploadedFile.FileName,
                        UploaderId = userId,
                        UploadedAt = DateTime.Now,
                        ContentType = uploadedFile.ContentType,
                        
                        Published = false
                    };
                    
                    fileRecord.Thumbnails = new List<Thumbnail>();
                    MemoryStream ims = new MemoryStream(); // proud pro pøíchozí obrázek
                    MemoryStream oms1 = new MemoryStream(); // proud pro ètvercový náhled
                    MemoryStream oms2 = new MemoryStream(); // proud pro ètvercový náhled
                    uploadedFile.CopyTo(ims); // vlož obsah do vstupního proudu
                    IImageFormat format; // zde si uložíme formát obrázku (JPEG, GIF, ...), budeme ho potøebovat pøi ukládání
                    using (Image image = Image.Load(ims.ToArray(), out format)) // vytvoøíme ètvercový náhled
                    {
                        int largestSize = Math.Max(image.Height, image.Width); // jaká je orientace obrázku?
                        if (image.Width > 2000 || image.Height > 2000)
                        {
                            ErrorMessage = "OOOPPPPSSSS image is too big";
                            return RedirectToPage("Upload");
                        }

                    }
                    using (Image image = Image.Load(ims.ToArray(), out format)) // vytvoøíme ètvercový náhled
                    {
                        int largestSize = Math.Max(image.Height, image.Width); // jaká je orientace obrázku?
                            if (image.Width > image.Height) // podle orientace zmìníme velikost obrázku
                            {
                                image.Mutate(x => x.Resize(0, _squareSize));
                            }
                            else
                            {
                                image.Mutate(x => x.Resize(_squareSize, 0));
                            }
                            image.Mutate(x => x.Crop(new Rectangle((image.Width - _squareSize) / 2, (image.Height - _squareSize) / 2, _squareSize, _squareSize)));
                            // obrázek oøízneme na ètverec
                            image.Save(oms1, format); // vložíme ho do výstupního proudu
                            fileRecord.Thumbnails.Add(new Thumbnail { Type = ThumbnailType.Square, Blob = oms1.ToArray() }); // a uložíme do databáze jako pole bytù
                    }
                    
                    try
                    {
                        _context.Files.Add(fileRecord); // a uložíme ho
                        //await _context.SaveChangesAsync(); // tím se nám vygeneruje jeho klíè ve formátu Guid
                        //filetogalleryId = _context.Files.Where(t=>t.UploaderId == userId).OrderByDescending(t=>t.UploadedAt).FirstOrDefault().Id;
                        filetogallerygallery = _context.Galleries.Where(t => t.OwnerId == userId && t.IsDefault == true).FirstOrDefault();
                        var fg = new StoredFileGallery { StoredFile = fileRecord, Gallery = filetogallerygallery };
                        _context.FilesGallery.Add(fg); // a uložíme ho
                        await _context.SaveChangesAsync();
                        var file = Path.Combine(_environment.ContentRootPath, "Uploads", fileRecord.Id.ToString());
                        // pod tímto klíèem uložíme soubor i fyzicky na disk
                        using (var fileStream = new FileStream(file, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        };
                        successfulProcessing++;
                    }
                    catch
                    {
                        failedProcessing++;
                    }
                    if (failedProcessing == 0)
                    {
                        SuccessMessage = "All files has been uploaded successfuly.";
                    }
                    else
                    {
                        ErrorMessage = "There were " + failedProcessing + " errors during uploading and processing of files.";
                    }
                    ErrorMessage = null;
                    SuccessMessage = "Saved";
                    return RedirectToPage("/MyFiles");
                }
                else
                {
                    ErrorMessage = "Not image";
                    return RedirectToPage("Upload");
                }

            }
            return RedirectToPage("/Index");
        }
    }
}

