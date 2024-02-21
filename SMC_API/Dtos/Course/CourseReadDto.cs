using SMC_API.Dtos.Attendance;
using SMC_API.Dtos.Result;
using System.Collections.Generic;

namespace SMC_API.Dtos.Course
{
    public class CourseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<AttendanceReadDto> Attendances { get; set; }
        public virtual IEnumerable<ResultReadDto> Results { get; set; }
    }
}
