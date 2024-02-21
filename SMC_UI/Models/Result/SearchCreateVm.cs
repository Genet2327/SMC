using SMC_UI.Models.ClassRoom;
using SMC_UI.Models.Course;
using SMC_UI.Models.Exam;
using SMC_UI.Models.Student;
using System.Collections.Generic;

namespace SMC_UI.Models.Result
{
    public class SearchCreateVm
    {
        public int ClassRoomId { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public IEnumerable<ClassRoomReadDto> ClassRoom { get; set; }
        public IEnumerable<CourseReadDto> Courses { set; get; }
        public IEnumerable<ExamReadDto> Exams { get; set; }
        public IEnumerable<StudentReadDto> Students { get; set; }
    }
}
