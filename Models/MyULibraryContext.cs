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
                optionsBuilder.UseSqlServer("Server=tcp:my-ulibrarydb.database.windows.net,1433;Initial Catalog=my-ulobrarydb;Persist Security Info=False;User ID=crack;Password=Root14003$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoanHistory>().HasKey(table => new {
                table.BookId,
                table.UserId,
                table.LoanDate
            });
        }
    }
}
