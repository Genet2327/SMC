using SMC_UI.Models.Course;
using SMC_UI.Models.Role;
using SMC_UI.Models.Student;
using System;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Attendance
{
    public class AttendanceReadDto
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int CourseId { get; set; }
        public virtual CourseReadDto Course { get; set; }     
        public int StudentId { get; set; }
        public virtual StudentReadDto Student { get; set; }
    }
}
