using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyULibrary_API.Models
{

    [Table("Genre")]
    public class Genre
    {
        public int GenreId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
