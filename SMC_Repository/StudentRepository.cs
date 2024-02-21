using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Paged;

namespace SMC_Repository
{
    public class StudentRepository : BaseRepo<Student>, IStudentRepository
    {
        protected SmcContext _smcContext { get; set; }

        public StudentRepository(SmcContext smcContext) : base(smcContext)
        {
            _smcContext = smcContext;
        }

        public override PagedList<Student> GetAll(QueryStringParameters parameters)
        {
            return PagedList<Student>.ToPagedList(_smcContext.Student.Include(c => c.ClassRoom).AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
