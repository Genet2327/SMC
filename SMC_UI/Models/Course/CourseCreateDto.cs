using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Course
{
    public class CourseCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
