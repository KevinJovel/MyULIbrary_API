using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyULibrary_API.Models
{
    [Table("LoanHistory")]
    public class LoanHistory
    {
        [Key]
        [Column(Order = 1)]
        public Book Book { get; set; }
        [Key]
        [Column(Order = 2)]
        public User User { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
