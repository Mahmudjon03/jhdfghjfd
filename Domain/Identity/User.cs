using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Login {  get; set; }
        public int RoleId { get; set; }
        public Role UserRole { get; set; }

    }
}
