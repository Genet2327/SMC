using System;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Attendance
{
    public class AttendanceUpdateDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string CourseId { get; set; }        
        [Required]
        public int StudentId { get; set; }
    }
}
