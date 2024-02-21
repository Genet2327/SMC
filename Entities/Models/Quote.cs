using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMC_Entities.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
