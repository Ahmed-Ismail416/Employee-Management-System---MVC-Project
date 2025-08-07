using DataAccess.Data.Context;
using DataAccess.Models.DepartmentModel;
using System.Reflection.Metadata.Ecma335;


namespace DataAccess.Repositories.DepartmentRepo
{
    public class DepartmentRepository(ApplicationDbContext _dbcontext) : GenericRepository<Department>(_dbcontext),IDepartmentRepostiory
    {
        
    }
}
