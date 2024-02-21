using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Exam
{
    public class ExamUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "Percentage strike must be between 0% and 100% ")]
        public int Percentage { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
