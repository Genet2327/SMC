using Microsoft.AspNetCore.Identity;

namespace SMC_Entities.Autentication
{
    public class RoleModel : IdentityRole
    {

    }
    public class Authorization
    {
        public enum Roles
        {
            Admin,
            User
        }
        public const string default_username = "user";
        public const string default_email = "admin@gmail.com";
        public const string default_password = "Admin1234!";
        public const Roles default_role = Roles.Admin;
    }
}
