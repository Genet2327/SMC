using SMC_UI.Models.Course;
using SMC_UI.Models.Exam;
using SMC_UI.Models.Student;

namespace SMC_UI.Models.Result
{
    public class ResulReadDto
    {
        public int Id { get; set; }
        public int Marks { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public ExamReadDto Exam { get; set; }
        public CourseReadDto Course { get; set; }
        public StudentReadDto Student { get; set; }
    }
}
