using System.Collections.Generic;

namespace SMC_Entities.Models
{
    public  class Course
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
