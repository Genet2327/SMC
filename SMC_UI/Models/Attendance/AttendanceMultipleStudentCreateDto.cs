using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using SMC_UI.Models.Course;
using SMC_UI.Models.Student;

namespace SMC_UI.Models.Attendance
{
    public class AttendanceMultipleStudentCreateDto
    {
        [Required]
        public bool Status { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<CourseReadDto> Courses { set; get; }
        public int[] StudentId { get; set; }
        public IEnumerable<StudentReadDto> Students { get; set; }
    }
}
