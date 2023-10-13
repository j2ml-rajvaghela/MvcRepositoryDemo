using Microsoft.EntityFrameworkCore;
using MvcRepositoryPatternDemo.Configuration;
using MvcRepositoryPatternDemo.Models;

namespace MvcRepositoryPatternDemo.DAL
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
