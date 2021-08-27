using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySample.WebApi.Models {
    [Table(nameof(Book))]
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
