
using DataAccess.Models.DepartmentModel;
using DataAccess.Models.IdentityModules;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Data.Context
{
    public class ApplicationDbContext(DbContextOptions options): IdentityDbContext<AppUser>(options)
    {
        
        public DbSet<Department> Departments { get; set; } //departments
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
