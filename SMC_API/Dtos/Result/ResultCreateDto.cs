using SMC_API.Dtos.Course;
using SMC_API.Dtos.Exam;
using SMC_API.Dtos.Student;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Result
{
    public class ResultCreateDto
    {
        [Required]
        public int Marks { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ExamId { get; set; }
        public ExamCreateDto Exam { get; set; }
        public CourseCreateDto Course { get; set; }
        public StudentCreateDto Student { get; set; }
    }

}

