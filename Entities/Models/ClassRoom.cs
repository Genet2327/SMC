namespace SMC_Entities.Models
{
    public  class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalCourses { get; set; }
        public bool IsActive { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
