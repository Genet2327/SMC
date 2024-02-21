using System.Collections.Generic;

namespace SMC_Entities.Models
{
    public  class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
