using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
