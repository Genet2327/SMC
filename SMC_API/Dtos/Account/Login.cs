using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Account
{
    public  class Login
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
