using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMC_Entities.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
