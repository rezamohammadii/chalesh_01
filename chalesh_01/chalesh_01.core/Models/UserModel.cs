using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; } = null!;
        [MaxLength(128)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(128)]
        public int Age { get; set; }  // The max length(128) for the "age" field is not logical : logical length 3       
        public string Website { get; set; } = string.Empty;
    }
}
