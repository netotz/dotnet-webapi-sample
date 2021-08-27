using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using LibrarySample.WebApi.Database;
using LibrarySample.WebApi.Models;

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

        [Fact]
        public async Task Add_BookWithGenreWithAuthor_SavesAll() {
            using var context = new LibraryContext(_options);

            await context.Database.EnsureCreatedAsync();

            var book = new Book {
                Title = "A Game of Thrones",
                Pages = 694,
                PublicationDate = new DateTime(1996, 8, 1),
                Author = new Author {
                    Name = "George R. R. Martin",
                    BirthDate = new DateTime(1948, 9, 20),
                },
                Genre = new Genre {
                    Name = "Fantasy"
                }
            };
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var books = await context.Books.ToListAsync();
            Assert.Single(books);

            var authors = await context.Authors.ToListAsync();
            Assert.Single(authors);

            var genres = await context.Genres.ToListAsync();
            Assert.Single(genres);

            var actualBook = books[0];
            Assert.Equal(1, actualBook.Id);
            Assert.Equal("A Game of Thrones", actualBook.Title);
            
            Assert.Equal(1, actualBook.AuthorId);
            Assert.Equal("George R. R. Martin", actualBook.Author.Name);

            Assert.Equal(1, actualBook.GenreId);
            Assert.Equal("Fantasy", actualBook.Genre.Name);
        }
    }
}