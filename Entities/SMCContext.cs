using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMC_Entities.Autentication;
using SMC_Entities.Models;

namespace SMC_Entities
{
    public class SmcContext : IdentityDbContext<ApplicationUser>
    {
        public SmcContext(DbContextOptions<SmcContext> opt) : base(opt)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Quote> quote { get; set; }
        public DbSet<Exam> Exam { get; set; }

    }
}

