using DataAccess.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.EmployeeRepo
{
    public class EmployeeRepository(ApplicationDbContext _dbcontext) : GenericRepository<Employee>(_dbcontext) , IEmployeeRepository
    {
    }
}
