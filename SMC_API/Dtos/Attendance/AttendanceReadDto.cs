using SMC_API.Dtos.Course;
using SMC_API.Dtos.Student;
using System;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Attendance
{
    public class AttendanceReadDto
    {       
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int CourseId { get; set; }        
        public int StudentId { get; set; }
        public virtual CourseReadDto Course { get; set; }
        public virtual StudentReadDto Student { get; set; }
    }
}
