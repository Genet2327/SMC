using SMC_UI.Dtos.Section;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.ClassRoom
{
    public class ClassRoomCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int TotalCourses { get; set; }
        public bool IsActive { get; set; }
        public int SectionId { get; set; }
        public IEnumerable<SectionReadDto> Sections { get; set; }
    }
}
