using SMC_API.Dtos.ClassRoom;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Section
{
    public class SectionCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int SectionId { get; set; }
        public int ClassRoomId { get; set; }
    }
}
