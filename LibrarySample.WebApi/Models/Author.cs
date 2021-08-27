using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySample.WebApi.Models {
    [Table(nameof(Author))]
    public class Author {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonym { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }
    }
}
