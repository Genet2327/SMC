using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SMC_API.Helpers;
using SMC_API.Service;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Autentication;
using SMC_Repository;
using System;
using System.Text;

namespace SMC_API
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
            //Adding DB Context with MSSQL
            services.AddDbContext<SmcContext>(options => options.UseSqlServer(_configuration.GetConnectionString("StMichaelConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("SMC_API")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SmcContext>();

            //Configuration from AppSettings
            services.Configure<JWT>(_configuration.GetSection("JWT"));

            //User Manager Service
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            // Withoutw Resposite
            // Resposite patern 
            // Gentric patter 


            //Adding Athentication -JWT
            services.AddAuthentication("MyDefaultScheme").AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = _configuration["JWT:Issuer"],
                        ValidAudience = _configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]))
                    };
                });

            services.AddControllers().AddNewtonsoftJson(s =>
                {
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // rest of services configuration
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //.... rest of app configuration
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMC_API v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}