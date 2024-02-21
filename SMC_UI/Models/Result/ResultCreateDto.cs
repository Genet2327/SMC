using SMC_UI.Models.Course;
using SMC_UI.Models.Exam;
using SMC_UI.Models.Student;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Result
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
        public IEnumerable<ExamReadDto> Exams { get; set; }
        public IEnumerable<StudentReadDto> Students { get; set; }
        public IEnumerable<CourseReadDto> Courses { set; get; }
    }
}
