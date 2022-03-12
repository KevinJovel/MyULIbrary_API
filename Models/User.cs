using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyULibrary_API.Models
{
    [Table("User")]
    public class User
    {
        public int UserId { get; set; }
        [StringLength(75)]
        public string FirstName { get; set; }
        [StringLength(75)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(25)]
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public ICollection<LoanHistory> LoanHistory { get; set; }
    }
}
