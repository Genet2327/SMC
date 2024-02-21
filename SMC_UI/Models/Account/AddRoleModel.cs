using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Account
{
    public class AddRoleModel
    {
        [Required]
        public string Email { get; set; }        
        [Required]
        public string Role { get; set; }
    }
}
