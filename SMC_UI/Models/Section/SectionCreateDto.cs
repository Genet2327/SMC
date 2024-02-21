using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Dtos.Section
{
    public class SectionCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
