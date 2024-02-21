using SMC_Entities.Dtos.Result;
using SMC_Entities.Models;
using System.Collections.Generic;

namespace SMC_Contracts
{
    public interface IResultRepository : IBaseRepo<Result>
    {
        IEnumerable<ResultGroupByStudentIdVm> GetByStudentId(int studentId);
    }
}
