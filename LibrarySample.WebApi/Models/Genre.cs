using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySample.WebApi.Models {
    [Table(nameof(Genre))]
    public class Genre {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
