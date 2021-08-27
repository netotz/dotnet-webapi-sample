
using LibrarySample.WebApi.Models;

using Microsoft.EntityFrameworkCore;

namespace LibrarySample.WebApi.Database {
    public class LibraryContext : DbContext {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
