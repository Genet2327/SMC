using SMC_UI.Models.Course;
using SMC_UI.Models.Role;
using SMC_UI.Models.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Attendance
{
    public class AttendanceUpdateDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int CourseId { get; set; }
        public IEnumerable<CourseReadDto> Courses { set; get; }
        [Required]
        public int StudentId { get; set; }
        public IEnumerable<StudentReadDto> Students { get; set; }
    }
}
