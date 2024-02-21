using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Exam
{
    public class ExamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public bool IsActive { get; set; }
    }
}
