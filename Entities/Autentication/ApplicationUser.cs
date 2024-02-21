using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_Entities.Autentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class AddRoleModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string Token { get; set; }
    }
    public class RegisterModel
    {
        public string Message { get; set; }
    }
}
