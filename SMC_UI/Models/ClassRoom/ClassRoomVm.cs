using SMC_UI.Dtos.Section;

namespace SMC_UI.Models.ClassRoom
{
    public class ClassRoomReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalCourses { get; set; }
        public bool IsActive { get; set; }

        public int SectionId { get; set; }
        public SectionReadDto Section { get; set; }
    }
}
