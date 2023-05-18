using chalesh_01.core.CodeFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.Dto
{
    public class Note
    {
        public int Id { get; set; } = Utils.RandomId();
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateModified { get; set; } = DateTime.Now;
        [Required]
        public int View { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public int UserId { get; set; }
    }
    public class NoteIn
    {
        public string Name { get; set; } = null!;
        [Required]
        public int View { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
