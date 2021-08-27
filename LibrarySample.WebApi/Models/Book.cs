using System;

namespace LibrarySample.WebApi.Models {
    public class Book {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
