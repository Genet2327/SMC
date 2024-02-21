using SMC_UI.Dtos.Result;
using SMC_UI.Models.Attendance;
using System.Collections.Generic;

namespace SMC_UI.Models.Student
{
    public class StudentViewDto
    {
        public StudentReadDto StudentRead { get; set; }
        public IEnumerable<ResultGroupByStudentIdVm> ResultsRead { get; internal set; }
        public IEnumerable<AttendanceReadDto> AttendancesRead { get; set; }
    }
}
