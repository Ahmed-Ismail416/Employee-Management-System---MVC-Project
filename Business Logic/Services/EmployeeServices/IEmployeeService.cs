using Business_Logic.DTOs.EmpoyeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withtracking = false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employee);
        int UpdateEmployee(UpdatedEmployeeDto employee);
        bool DeleteEmployee(int id);


    }
}
