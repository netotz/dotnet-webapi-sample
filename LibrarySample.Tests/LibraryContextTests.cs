using System.Collections.Generic;
using System.Threading.Tasks;

using LibrarySample.WebApi.Database;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using Xunit;

namespace LibrarySample.Tests {
    public class LibraryContextTests {
        private readonly DbContextOptions<LibraryContext> _options;

        public LibraryContextTests() {
            var connection = new SqliteConnection("Mode=memory");
            connection.Open();

            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlite(connection)
                .Options;
        }

        [Fact]
        public async Task LibraryContext_Migration_Succeeds() {
            using var context = new LibraryContext(_options);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var authors = await context.Authors.ToListAsync();
            Assert.Empty(authors);

            var books = await context.Books.ToListAsync();
            Assert.Empty(books);

            var genres = await context.Genres.ToListAsync();
            Assert.Empty(genres);
        }
    }
}
