using SMC_Entities.Dtos.Result;
using System.Collections.Generic;

namespace SMC_Entities.ViewModel
{
    public class StudentRedByClassRoomNumberVm
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
