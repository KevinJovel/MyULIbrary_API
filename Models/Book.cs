using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyULibrary_API.Models
{
    [Table("Book")]
    public class Book
    {
        public int BookID { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public int Stock { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public ICollection<LoanHistory> LoanHistory { get; set; }
    }
}
