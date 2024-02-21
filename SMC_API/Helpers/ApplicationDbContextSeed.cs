using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMC_Entities;
using SMC_Entities.Autentication;
using SMC_Entities.Models;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using static SMC_Entities.Autentication.Authorization;

namespace SMC_API.Helpers
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = Authorization.default_username,
                Email =
                Authorization.default_email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.default_password);
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
            }
        }

        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new SmcContext(serviceProvider.GetRequiredService<DbContextOptions<SmcContext>>()))
                {
                    if (!context.Exam.Any())
                    {


                        _ = context.Exam.Add(new Exam
                        {
                            Name = "Exam 1",
                            Percentage = 40,
                            IsActive = true
                        });

                        _ = context.Exam.Add(new Exam
                        {
                            Name = "Exam 2",
                            Percentage = 40,
                            IsActive = true
                        });

                        _ = context.Exam.Add(new Exam
                        {
                            Name = "Quize",
                            Percentage = 20,
                            IsActive = true
                        });

                        context.SaveChanges();
                    }
                }
                using (var context = new SmcContext(serviceProvider.GetRequiredService<DbContextOptions<SmcContext>>()))
                {
                    if (!context.Section.Any())
                    {

                        _ = context.Section.Add(new Section
                        {
                            Name = "A"
                        });

                        _ = context.Section.Add(new Section
                        {
                            Name = "B"
                        });

                        context.SaveChanges();
                    }
                }
                using (var context = new SmcContext(serviceProvider.GetRequiredService<DbContextOptions<SmcContext>>()))
                {
                    if (!context.ClassRoom.Any())
                    {

                        _ = context.ClassRoom.Add(new ClassRoom
                        {
                            Name = "Ke Damaye",
                            SectionId = 1,
                            TotalCourses = 2
                        });

                        _ = context.ClassRoom.Add(new ClassRoom
                        {
                            Name = "Gread 1",
                            SectionId = 1,
                            TotalCourses = 2
                        });

                        _ = context.ClassRoom.Add(new ClassRoom
                        {
                            Name = "Gread 2",
                            SectionId = 1,
                            TotalCourses = 2
                        });
                        context.SaveChanges();
                    }
                }
                using (var context = new SmcContext(serviceProvider.GetRequiredService<DbContextOptions<SmcContext>>()))
                {
                    if (!context.Student.Any())
                    {

                        _ = context.Student.Add(new Student
                        {
                            FirstName = "Abel",
                            MiddleName = "Sintayehu",
                            LastName = "Ararso",
                            Telephone = "405050",
                            Age = 21,
                            Adress = "Test",
                            ChristeningName = "bod",
                            GenderId = 1,
                            OccupationType = "a",
                            MotherName = "Test",
                            ClassRoomId = 1,
                        });

                        _ = context.Student.Add(new Student
                        {
                            FirstName = "Kak",
                            MiddleName = "l",
                            LastName = "Sintayehu",
                            Telephone = "405050",
                            Age = 21,
                            Adress = "Test",
                            ChristeningName = "bod",
                            GenderId = 1,
                            OccupationType = "a",
                            MotherName = "Test",
                            ClassRoomId = 1
                        });

                        _ = context.Courses.Add(new Course
                        {
                            Name = "Math"
                        });

                        _ = context.Courses.Add(new Course
                        {
                            Name = "Chem"
                        });

                        context.SaveChanges();
                    }
                }
            }

        }
    }
}
