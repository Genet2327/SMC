using SMC_Entities.Dtos.Result;
using System.Collections.Generic;

namespace SMC_API.Dtos.ClassRoom
{
    public class StudentRedByClassRoomNumberDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public double TotalScore { get; set; }
        public int AttendanceScore { get; set; }
        public string ChristeningName { get; set; }
        public int TotalCourses { get; set; }
        public IEnumerable<ResultGroupByStudentIdVm> resultGroupByStudentIdVms { get; set; }
    }
}
