using IdentitySetupTest5.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentitySetupTest5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CoffeeCup> Cups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
                Name = "Test"
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d50f61e2-f8fa-42c7-acc4-8d83398d375e",
                UserId = "32a2f732-6c98-4480-92e6-610b67e4cfa9"
            });
        }


    }
}
