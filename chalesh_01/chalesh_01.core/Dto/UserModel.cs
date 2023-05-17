using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.Dto
{
    public class UserModelIn
    {
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; } = null!;
        [MaxLength(128)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public int Age { get; set; }  // The max length(128) for the "age" field is not logical        
        public string Website { get; set; } = string.Empty;
    }

    public class UserModelOut
    {
        public int id { get; set; } = RandomNumber.RandomId();
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; } = null!;
        [MaxLength(128)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public int Age { get; set; }  // The max length(128) for the "age" field is not logical        
        public string Website { get; set; } = string.Empty;
    }

    public class RandomNumber
    {
        public static int RandomId()
        {
            Random random = new Random();
            return random.Next(10, 100);
        }
       
    }

}
