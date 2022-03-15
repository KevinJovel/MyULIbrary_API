using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyULibrary_API.Models
{
    [Table("LoanHistory")]
    public class LoanHistory
    {
        [ForeignKey("BookId")]
        [JsonIgnore]
        public Book Book { get; set; }
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
