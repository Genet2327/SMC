using SMC_UI.Dtos.Result;
using System.Collections.Generic;

namespace SMC_UI.Models.ClassRoom
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

    public class StudentRedByClassRoomNumberVm
    {
        public ClassRoomReadDto ClassRoom { get; set; }
        public IEnumerable<StudentRedByClassRoomNumberDto> Data { get; set; }
        public int Id { get; internal set; }
    }
}
