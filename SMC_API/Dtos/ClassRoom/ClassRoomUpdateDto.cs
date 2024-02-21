namespace SMC_API.Dtos.ClassRoom
{
    public class ClassRoomUpdateDto
    {
        public string Name { get; set; }
        public int TotalCourses { get; set; }
        public bool IsActive { get; set; }
        public int SectionId { get; set; }
    }
}
