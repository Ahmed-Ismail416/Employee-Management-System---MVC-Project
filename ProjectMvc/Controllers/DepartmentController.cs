using Business_Logic.DTOs;
using Business_Logic.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectMvc.ViewModels;
using ProjectPresentation.ViewModels.Department;
using System.Diagnostics;

namespace ProjectMvc.Controllers;

public class DepartmentController(IDepartmentServices _departmentService,ILogger<DepartmentController> _logger, IWebHostEnvironment _webHostEnvironment) : Controller
{
    
    public IActionResult Index()
    {
        var departments = _departmentService.GetAllDepartments();
        return View(departments);
    }

    #region Create
    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreatedDepartmentDto department)
    {
        if (ModelState.IsValid) // Server Side validation
        {
            try
            {
                int result = _departmentService.AddDepartment(department);
                string message;
                if (result > 0)
                {
                    message = $"Department {department.Name} created successfully.";
                }else
                {
                    message = $"Failed to create department {department.Name}.";
                }
                TempData["Message"] = message;
                return RedirectToAction(nameof(Index) );
            }
            catch(Exception ex)
            {
                // in Development
                if (_webHostEnvironment.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }else
                {
                    // in Production
                    _logger.LogError(ex, "Error occurred while creating department.");
                    ModelState.AddModelError("", "An error occurred while creating the department. Please try again later.");
                }
            }  
        }
        return View(department);
    }
    #endregion

    #region Details
    public IActionResult Details(int? id)
    {
        if(!id.HasValue) return NotFound();
        var department = _departmentService.GetById(id.Value);
        if(department == null) return NotFound();
        return View(department);
    }
    #endregion

    #region Edit
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if(!id.HasValue) return NotFound();
        var department = _departmentService.GetById(id.Value);
        if(department == null) return NotFound();
        var updatedDepartment = new DepartmentEditViewModel
        {
            Name = department.Name,
            Code = department.Code,
            Description = department.Discription,
            DateOfCreation = department.CreatedOn
        };
       
        return View(updatedDepartment);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute]int id, DepartmentEditViewModel department)
    {
        if(!ModelState.IsValid) // Server Side validation
        {
            return View(department);
        }
        // Map ViewModel to DTO
        var departmentDto = new UpdatedDepartmentDto()
        {
            Id = id,
            Name = department.Name,
            Code = department.Code,
            Discription = department.Description,
            DateOfCreation = department.DateOfCreation
        };
        try
        {
            var result = _departmentService.UpdateDepartment( departmentDto);
            if(result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Failed to update department.");
        }catch(Exception ex)
        {
            if (_webHostEnvironment.IsDevelopment())
            {
                ModelState.AddModelError("", ex.Message);
            }
            else
            {
                _logger.LogError(ex, "Error occurred while updating department.");
                ModelState.AddModelError("", "An error occurred while updating the department. Please try again later.");
            }
        }
        return View(department);
    }
    #endregion

    #region Delete
  

    [HttpPost]
    public IActionResult Delete(int id)
    {
       if(id == 0) return NotFound();

        try
        {
            var result = _departmentService.DeleteDepartment(id);
            if(result)
            {
                return RedirectToAction(nameof(Index) );
            }
            ModelState.AddModelError("", "Failed to delete department.");
        }catch(Exception ex)
        {
            if (_webHostEnvironment.IsDevelopment())
            {
                ModelState.AddModelError("", ex.Message);
            }
            else
            {
                _logger.LogError(ex, "Error occurred while deleting department.");
                ModelState.AddModelError("", "An error occurred while deleting the department. Please try again later.");
            }
        }
        return View();
    }
    #endregion
}
