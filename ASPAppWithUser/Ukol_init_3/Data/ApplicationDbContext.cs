using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Ukol_init_3.Model;

namespace Ukol_init_3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ForumThread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ForumThread>().HasData(new ForumThread { Id = 1 , Name = "Test" });
            //builder.Entity<Comment>().HasData(new Comment { Id = 1 , Thread = 1 , Message = "Test"});
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
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
                FirstName = "Vaclav",
                LastName = "Kozeny"
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                UserId = "32a2f732-6c98-4480-92e6-610b67e4cfa9"
            });
        }
    }
}
