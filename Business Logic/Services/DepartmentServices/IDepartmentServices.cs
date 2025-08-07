using Business_Logic.DTOs;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public interface IDepartmentServices
    {

        public IEnumerable<DepartmentDto> GetAllDepartments();
        public DepartmentDetailViewModel? GetById(int id);
        public int AddDepartment(CreatedDepartmentDto department);
        public int UpdateDepartment(UpdatedDepartmentDto department);
        public bool DeleteDepartment(int id);


    }
}
