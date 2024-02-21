using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Account
{
    public class Register 
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
