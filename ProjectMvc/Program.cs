using Business_Logic.Profiles;
using Business_Logic.Services;
using Business_Logic.Services.AttachmentServices;
using Business_Logic.Services.EmployeeServices;
using DataAccess.Data.Context;
using DataAccess.Models.EmployeeModel;
using DataAccess.Models.IdentityModules;
using DataAccess.Repositories;
using DataAccess.Repositories.DepartmentRepo;
using DataAccess.Repositories.EmployeeRepo;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProjectMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region AddServices
            builder.Services.AddControllersWithViews(Options =>
                Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
            //builder.Services.AddScoped<IDepartmentRepostiory, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();



            #endregion

            var app = builder.Build();

            #region Http Request Pipeline

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");
            #endregion
            app.Run();
        }
    }
}
