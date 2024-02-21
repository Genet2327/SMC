using SMC_Entities.Models;
using System.Collections.Generic;

namespace SMC_Contracts
{
    public interface IAttendanceRepository : IBaseRepo<Attendance>
    {
        IEnumerable<Attendance> GetByStudentId(int studentId);
    }
}
