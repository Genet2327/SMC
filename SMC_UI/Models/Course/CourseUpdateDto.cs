using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Course
{
    public class CourseUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
