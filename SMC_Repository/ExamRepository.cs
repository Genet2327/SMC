using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Models;

namespace SMC_Repository
{
    public class ExamRepository :BaseRepo<Exam> , IExamRepository
    {
        public ExamRepository(SmcContext smcContext) : base(smcContext)
        {

        }
    }
}
