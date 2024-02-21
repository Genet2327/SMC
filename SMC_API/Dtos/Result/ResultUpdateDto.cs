using SMC_API.Dtos.Course;
using SMC_API.Dtos.Exam;
using SMC_API.Dtos.Student;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Result
{
    public class ResultUpdateDto
    {
        [Required]
        public int Marks { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ExamId { get; set; }
        public ExamUpdateDto Exam { get; set; }
        public CourseUpdateDto Course { get; set; }
        public StudentUpdateDto Student { get; set; }
    }
}
