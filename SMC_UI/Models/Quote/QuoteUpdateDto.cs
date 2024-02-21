using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Quote
{
    public class QuoteUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
