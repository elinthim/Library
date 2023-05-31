using Library.Models;
using Microsoft.EntityFrameworkCore;



namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        public DbSet<Customer> Customers { get; set; } = default!;



        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<BookConnection> BookConnections { get; set; }
    }
}
