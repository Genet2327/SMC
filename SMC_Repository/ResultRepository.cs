using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Collections.Generic;
using System.Linq;
using SMC_Entities.Dtos.Result;

namespace SMC_Repository
{
    public class ResultRepository : BaseRepo<Result>, IResultRepository
    {
        protected SmcContext _smcContext { get; set; }

        public ResultRepository(SmcContext smcContext) : base(smcContext)
        {
            _smcContext = smcContext;
        }
        public override PagedList<Result> GetAll(QueryStringParameters parameters)
        {
            return PagedList<Result>.ToPagedList(_smcContext.Result.Include(e => e.Exam).Include(s => s.Student).Include(c => c.Course).AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize);
        }

        public IEnumerable<ResultGroupByStudentIdVm> GetByStudentId(int studentId)
        {
            var resultGroup = _smcContext.Result.Where(r => r.StudentId == studentId).Include(c => c.Course)
                .GroupBy(l => new { CourseName = l.Course.Name})
               .Select(g => new ResultGroupByStudentIdVm
               {
                   TotalScore = g.Average(y => y.Marks),
                   CourseName = g.Key.CourseName
               });
            return resultGroup;
        }
    }
}
