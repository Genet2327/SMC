using System.Collections.Generic;

namespace SMC_UI.Models.Account
{
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
