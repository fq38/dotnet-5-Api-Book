using Microsoft.EntityFrameworkCore;

namespace WebApi5shirleyrios.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions <BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }


    }
}
