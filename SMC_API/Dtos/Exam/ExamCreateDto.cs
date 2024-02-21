using SMC_API.Dtos.Result;
using System.Collections.Generic;

namespace SMC_API.Dtos.Exam
{
    public class ExamCreateDto
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ResultReadDto> Results { get; set; }
    }
}
