using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Upload3.Model;

namespace Upload3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StoredFile> Files { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<StoredFileGallery> FilesGallery { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Thumbnail>().HasKey(t => new { t.FileId, t.Type });
            builder.Entity<StoredFileGallery>()
                .HasKey(bc => new { bc.StoredFileId, bc.GalleryId });
            builder.Entity<StoredFileGallery>()
                .HasOne(bc => bc.StoredFile)
                .WithMany(b => b.StoredFileGalleries)
                .HasForeignKey(bc => bc.StoredFileId);
            builder.Entity<StoredFileGallery>()
                .HasOne(bc => bc.Gallery)
                .WithMany(c => c.StoredFileGalleries)
                .HasForeignKey(bc => bc.GalleryId);
            //builder.Entity<StoredFile>().HasKey(t => new {t.Id, t.Gallery, t.Uploader});
            //builder.Entity<ForumThread>().HasData(new ForumThread { Id = 1 , Name = "Test" });
            //builder.Entity<Comment>().HasData(new Comment { Id = 1 , Thread = 1 , Message = "Test"});
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                Email = "vackoze019@pslib.cz",
                NormalizedEmail = "VACKOZE019@PSLIB.CZ",
                EmailConfirmed = true,
                UserName = "vackoze019@pslib.cz",
                NormalizedUserName = "VACKOZE019@PSLIB.CZ",
                LockoutEnabled = false,
                SecurityStamp = String.Empty,
                PasswordHash = hasher.HashPassword(null, "beruska"),

            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                UserId = "32a2f732-6c98-4480-92e6-610b67e4cfa9"
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "32a2f732-6c98-4480-92e6-610b67e4cfa7",
                Email = "vackoze019@g.pslib.cz",
                NormalizedEmail = "VACKOZE019@G.PSLIB.CZ",
                EmailConfirmed = true,
                UserName = "vackoze019@g.pslib.cz",
                NormalizedUserName = "VACKOZE019@G.PSLIB.CZ",
                LockoutEnabled = false,
                SecurityStamp = String.Empty,
                PasswordHash = hasher.HashPassword(null, "beruska"),

            });
            builder.Entity<Gallery>().HasData(new Gallery
            {
                Id = 2,
                OwnerId = "32a2f732-6c98-4480-92e6-610b67e4cfa7",
                Name = "Default",
                IsDefault = true
            });
            builder.Entity<Gallery>().HasData(new Gallery
            {
                Id = 1,
                OwnerId = "32a2f732-6c98-4480-92e6-610b67e4cfa9",
                Name = "Default",
                IsDefault = true
            });
        }
    }
}
