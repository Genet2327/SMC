using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Models;

namespace SMC_Repository
{
    public class SectionRepository :BaseRepo<Section> , ISectionRepository
    {
        public SectionRepository(SmcContext smcContext) : base(smcContext)
        {

        }
    }
}
