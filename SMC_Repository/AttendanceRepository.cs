using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;
using System.Linq;

namespace SMC_Repository
{
    public class AttendanceRepository :BaseRepo<Attendance> , IAttendanceRepository
    {
        protected SmcContext _smcContext { get; set; }

        public AttendanceRepository(SmcContext smcContext) : base(smcContext)
        {
            _smcContext = smcContext;
        }
        public override PagedList<Attendance> GetAll(QueryStringParameters parameters)
        {
            return PagedList<Attendance>.ToPagedList(_smcContext.Attendance.Include(s => s.Student).Include(c => c.Course).AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize);
        }
        public IEnumerable<Attendance> GetByStudentId(int studentId)
        {
            return _smcContext.Attendance.Where(r => r.StudentId == studentId).Include(c => c.Course).ToList();
        }
    }
}
