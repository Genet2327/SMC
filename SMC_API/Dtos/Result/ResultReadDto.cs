using SMC_API.Dtos.Course;
using SMC_API.Dtos.Exam;
using SMC_API.Dtos.Student;

namespace SMC_API.Dtos.Result
{
    public class ResultReadDto
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public string CourseId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public ExamReadDto Exam { get; set; }
        public CourseReadDto Course { get; set; }
        public StudentReadDto Student { get; set; }
    }
}
