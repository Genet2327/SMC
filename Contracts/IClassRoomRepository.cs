using SMC_Entities.Models;
using SMC_Entities.ViewModel;
using System.Collections.Generic;

namespace SMC_Contracts
{
    public interface IClassRoomRepository : IBaseRepo<ClassRoom>
    {
        IEnumerable<StudentRedByClassRoomNumberVm> GetAllStudentByClassRoomId(int ClassRoomId);
    }
}
