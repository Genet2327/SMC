using System.ComponentModel.DataAnnotations.Schema;

namespace SMC_Entities.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Marks { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
