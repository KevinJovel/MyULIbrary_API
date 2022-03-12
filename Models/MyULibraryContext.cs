using Microsoft.EntityFrameworkCore;

namespace MyULibrary_API.Models
{
    public class MyULibraryContext : DbContext
    {
        public MyULibraryContext(DbContextOptions<MyULibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoanHistory> LoanHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6301TK6\\SQLEXPRESS;Initial Catalog=MyULibraryDB;Integrated Security=True");
            }
        }
    }
}
