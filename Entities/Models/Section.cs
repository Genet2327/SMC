using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_Entities.Models
{
    public  class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}
