using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMC_UI.Models;
using SMC_UI.Service;
using System;

namespace SMC_UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSingleton(_configuration);
            services.Configure<MySettings>(_configuration.GetSection("MySettings"));
            services.AddHttpClient("SMC_API", config =>
            {
                config.BaseAddress = new Uri(_configuration["MySettings:ApiBaseUrl"]);
                config.Timeout = new TimeSpan(0, 0, 30);
                config.DefaultRequestHeaders.Clear();
                //config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token")?.Value);

            });

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IQuoteService, QuoteService>();
            // dependency injection  call servise 



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "MySessionCookie";
                    options.LoginPath = "/Account/Login";
                    options.SlidingExpiration = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,
            };

            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
