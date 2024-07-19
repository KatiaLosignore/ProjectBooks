using Microsoft.EntityFrameworkCore;
using ProjectBooks.Entities;

namespace ProjectBooks.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)   
        { 

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        
    }
}
