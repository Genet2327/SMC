using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Dtos.Section
{
    public class SectionUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
