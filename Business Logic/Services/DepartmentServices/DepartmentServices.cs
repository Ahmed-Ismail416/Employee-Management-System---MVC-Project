using Business_Logic.DTOs;
using Business_Logic.Factories;
using DataAccess.Repositories.DepartmentRepo;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public  class DepartmentServices(IUnitOfWork unitOfWork):IDepartmentServices // Injection
    {
        // Get All
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = unitOfWork._departmentrepostiory.GetAll(false); // without tracking
            return departments.Select(d => d.DepartmentToDto());
        }

        // Get By Id
        public DepartmentDetailViewModel? GetById(int id)
        {
            var department = unitOfWork._departmentrepostiory.GetById(id);
            return department?.DepartmentToDetailsDto();
        }

        // Add
        public int AddDepartment(CreatedDepartmentDto department)
        {
            return unitOfWork._departmentrepostiory.Insert(department.ToEntity());
        }

        // Update 
        public int UpdateDepartment(UpdatedDepartmentDto department)
        {
             unitOfWork._departmentrepostiory.Update(department.ToEntity());
            return unitOfWork.SaveChanges();
        }

        // Delete
        public bool DeleteDepartment(int id)
        {
            var department = unitOfWork._departmentrepostiory.GetById(id);
            if (department == null)
            {
                return false; // or throw an exception
            }
            else
            {
                unitOfWork._departmentrepostiory.Delete(department);
                return unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
