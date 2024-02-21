using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Quote
{
    public class QuoteCreateDto
    {
        [Required]
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
