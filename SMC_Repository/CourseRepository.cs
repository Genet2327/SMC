using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Models;

namespace SMC_Repository
{
    public class CourseRepository :BaseRepo<Course> , ICourseRepository
    {
        public CourseRepository(SmcContext smcContext) : base(smcContext)
        {

        }
    }
}
