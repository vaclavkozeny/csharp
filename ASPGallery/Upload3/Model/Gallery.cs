using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upload3.Model
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OwnerId")]
        public IdentityUser Owner { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public ICollection<StoredFileGallery> StoredFileGalleries { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPublic { get; set; }
        public byte[] Blod { get; set; }

    }
}
