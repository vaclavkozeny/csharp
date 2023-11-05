using Books.Model;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>().HasData(new Book { Name = "test", BookId = 1, Pages = 69 });
            builder.Entity<Author>().HasData(new Author { AuthorId = 1, Firstname = "Pepa", Lastname = "Zdepa" });

        }
    }
}
