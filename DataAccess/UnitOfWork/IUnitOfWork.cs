using DataAccess.Repositories.DepartmentRepo;
using DataAccess.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDepartmentRepostiory _departmentrepostiory { get;  }
        public IEmployeeRepository _employeerepository { get;  }
        int SaveChanges();
    }
}
