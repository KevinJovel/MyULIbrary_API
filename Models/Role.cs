using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyULibrary_API.Models
{
    [Table("Role")]
    public class Role
    {
        public int RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
