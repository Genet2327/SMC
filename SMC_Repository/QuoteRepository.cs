using SMC_Contracts;
using SMC_Entities.Models;
using SMC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Repository
{
    public class QuoteRepository : BaseRepo<Quote>, IQuoteRepository
    {
        protected SmcContext _smcContext { get; set; }

        public QuoteRepository(SmcContext smcContext) : base(smcContext)
        {
            _smcContext = smcContext;
        }
    
    }
}
