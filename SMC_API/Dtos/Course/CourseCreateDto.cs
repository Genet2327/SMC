using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Course
{
    public class CourseCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
