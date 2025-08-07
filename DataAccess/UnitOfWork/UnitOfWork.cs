using DataAccess.Data.Context;
using DataAccess.Repositories.DepartmentRepo;
using DataAccess.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly Lazy<IDepartmentRepostiory> _departmentrepostiory;

        private readonly Lazy<IEmployeeRepository> _employeerepository;
        public UnitOfWork( ApplicationDbContext applicationDbContext)
        {
            _departmentrepostiory = new Lazy<IDepartmentRepostiory>(()=> new DepartmentRepository(applicationDbContext));
            _employeerepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(applicationDbContext));
            _applicationDbContext = applicationDbContext;
        }

        IDepartmentRepostiory IUnitOfWork._departmentrepostiory => _departmentrepostiory.Value;

        IEmployeeRepository IUnitOfWork._employeerepository => _employeerepository.Value;

        public int SaveChanges()
        {
            return _applicationDbContext.SaveChanges();
        }
    }
}
