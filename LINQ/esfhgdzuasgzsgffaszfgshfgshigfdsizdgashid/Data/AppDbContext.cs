using esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public AppDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            op.UseSqlite(@"Data Source=test.sqlite");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 1, Name = "Africa" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 2, Name = "Asia" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 3, Name = "Europe" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 4, Name = "North America" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 5, Name = "South America" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 6, Name = "Australia And Oceania" });
            modelBuilder.Entity<Continent>().HasData(new Continent { Id = 7, Name = "Antarctica" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "China", ContinentId = 2, Population = 1406357120, LandArea = 9388211, FertilityRate = 1.7, GDP = 14860775 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "India", ContinentId = 2, Population = 1380004385, LandArea = 2973190, FertilityRate = 2.2, GDP = 2592583 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "United States", ContinentId = 4, Population = 331002651, LandArea = 9147420, FertilityRate = 1.8, GDP = 20807269 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Indonesia", ContinentId = 2, Population = 273523615, LandArea = 1811570, FertilityRate = 2.3, GDP = 1088768 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Nigeria", ContinentId = 1, Population = 206139589, LandArea = 910770, FertilityRate = 5.4, GDP = 442976 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "Russia", ContinentId = 3, Population = 145934462, LandArea = 16376870, FertilityRate = 1.8, GDP = 1464078 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 7, Name = "Czechia", ContinentId = 3, Population = 10708981, LandArea = 77240, FertilityRate = 1.6, GDP = 241975 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 8, Name = "Poland", ContinentId = 3, Population = 37846611, LandArea = 306230, FertilityRate = 1.4, GDP = 580894 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 9, Name = "Slovakia", ContinentId = 3, Population = 5459642, LandArea = 48088, FertilityRate = 1.5, GDP = 101892 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 10, Name = "France", ContinentId = 3, Population = 65273511, LandArea = 547557, FertilityRate = 1.9, GDP = 2551451 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 11, Name = "United Kingdom", ContinentId = 3, Population = 67886011, LandArea = 241930, FertilityRate = 1.8, GDP = 2638296 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 12, Name = "Germany", ContinentId = 3, Population = 83783942, LandArea = 547557, FertilityRate = 1.8, GDP = 3780553 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 13, Name = "Egypt", ContinentId = 1, Population = 102334404, LandArea = 995450, FertilityRate = 3.3, GDP = 3618753 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 14, Name = "Venezuela", ContinentId = 5, Population = 28435940, LandArea = 882050, FertilityRate = null, GDP = 134960 });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 15, Name = "Monaco", ContinentId = 3, Population = 39242, LandArea = 1, FertilityRate = null, GDP = 7423 });
        }
    }
}
