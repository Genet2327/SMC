using SMC_API.Dtos.ClassRoom;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Section
{
    public class SectionUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ClassRoomId { get; set; }
    }
}
