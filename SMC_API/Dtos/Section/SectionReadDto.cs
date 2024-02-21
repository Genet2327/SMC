using SMC_API.Dtos.ClassRoom;
using System.Collections.Generic;

namespace SMC_API.Dtos.Section
{
    public class SectionReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ClassRoomReadDto> ClassRooms { get; set; }
    }
}
