using AspNetCoreGeneratedDocument;
using Business_Logic.DTOs.EmpoyeeDtos;
using Business_Logic.Services.EmployeeServices;
using DataAccess.Models.EmployeeModel;
using DataAccess.Models.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectPresentation.ViewModels.Employee;

namespace ProjectPresentation.Controllers
{
    public class EmployeeController(IEmployeeService _emloyeeservice, ILogger<EmployeeController> _logger, IWebHostEnvironment _env ) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employees = _emloyeeservice.GetAllEmployees(EmployeeSearchName);
            return View(Employees);
        }
        #region Create
        [HttpGet]
        public IActionResult Create() => View();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeviewmodel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var employee = new CreateEmployeeDto()
                    {
                        Name = employeeviewmodel.Name,
                        Age = employeeviewmodel.Age,
                        Address = employeeviewmodel.Address,
                        Salary = employeeviewmodel.Salary,
                        IsActive = employeeviewmodel.IsActive,
                        Email = employeeviewmodel.Email,
                        PhoneNumber = employeeviewmodel.PhoneNumber,
                        HiringDate = employeeviewmodel.HiringDate,
                        Gender = employeeviewmodel.Gender,
                        EmployeeType = employeeviewmodel.EmployeeType,
                        DepartmentId = employeeviewmodel.DepartmentId,
                        Image = employeeviewmodel.Image
                    };
                    int result = _emloyeeservice.CreateEmployee(employee);
                    if(result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Failed to create employee.");
                }
                catch (Exception ex)
                {
                    if(_env.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex, "Error occurred while creating employee.");
                        ModelState.AddModelError("", "An error occurred while creating the employee. Please try again later.");
                    }
                }
               
            }
            return View(employeeviewmodel);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)  return NoContent();
            var employee = _emloyeeservice.GetEmployeeById(id.Value);
            return employee is null ? NotFound(): View(employee);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return NotFound();
            var employee = _emloyeeservice.GetEmployeeById(id.Value);
            var employeedto = new EmployeeViewModel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId,
                
            };
            return employee is null ? NotFound() : View(employeedto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id,EmployeeViewModel employeeviewmodel)
        {
            if(!id.HasValue ) return NotFound();
            if (!ModelState.IsValid) return View(employeeviewmodel);
            try
            {
                var employee = new UpdatedEmployeeDto()
                {
                    Id = id.Value,
                    Name = employeeviewmodel.Name,
                    Age = employeeviewmodel.Age,
                    Address = employeeviewmodel.Address,
                    Salary = employeeviewmodel.Salary,
                    IsActive = employeeviewmodel.IsActive,
                    Email = employeeviewmodel.Email,
                    PhoneNumber = employeeviewmodel.PhoneNumber,
                    HiringDate = employeeviewmodel.HiringDate,
                    Gender = employeeviewmodel.Gender,
                    EmployeeType = employeeviewmodel.EmployeeType,
                    DepartmentId = employeeviewmodel.DepartmentId,
                    Image = employeeviewmodel.Image,
                };

                var result = _emloyeeservice.UpdateEmployee(employee);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to update employee.");
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    _logger.LogError(ex, "Error occurred while updating employee.");
                    ModelState.AddModelError("", "An error occurred while updating the employee. Please try again later.");
                }
            }
            return View(employeeviewmodel);
        }

        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();
            try
            {
                var result = _emloyeeservice.DeleteEmployee(id.Value);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to delete employee.");
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    _logger.LogError(ex, "Error occurred while deleting employee.");
                    ModelState.AddModelError("", "An error occurred while deleting the employee. Please try again later.");
                }
            }
            return View(nameof(Index));
        }
        #endregion
    }
}
