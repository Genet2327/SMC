using System;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Attendance
{
    public class AttendanceCreateDto
    {
        [Required]
        public bool Status { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
