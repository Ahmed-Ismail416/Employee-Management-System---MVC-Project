using AutoMapper;
using Business_Logic.DTOs.EmpoyeeDtos;
using Business_Logic.Services.AttachmentServices;
using DataAccess.Models.EmployeeModel;
using DataAccess.Repositories;
using DataAccess.Repositories.EmployeeRepo;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.EmployeeServices
{
    public class EmployeeServices(IUnitOfWork _unitOfWork, IMapper _mapper, IAttachmentService _attachmentService) : IEmployeeService
    {

        public IEnumerable<EmployeeDto> GetAllEmployees( string? EmployeeSearchName, bool withtracking = false)
        {
            IEnumerable<Employee> employees;
            if(string.IsNullOrWhiteSpace(EmployeeSearchName))
                employees = _unitOfWork._employeerepository.GetAll( withtracking);
            else
                employees = _unitOfWork._employeerepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var employeesdto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

                return employeesdto;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork._employeerepository.GetById(id);
            return employee is null? null: _mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }
        public int CreateEmployee(CreateEmployeeDto employeedto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeedto);
            if(employeedto.Image is not null)
            {
                employee.ImageName = _attachmentService.UploadFile(employeedto.Image, "Images");
            }

            return _unitOfWork._employeerepository.Insert(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeedto)
        {
            var employee = _mapper.Map<UpdatedEmployeeDto, Employee>(employeedto);
            if (employeedto.Image is not null)
                employee.ImageName = _attachmentService.UploadFile(employeedto.Image,"Images");
            _unitOfWork._employeerepository.Update(employee);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork._employeerepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                _unitOfWork._employeerepository.Update(employee) ;
                return _unitOfWork.SaveChanges() > 0 ? true : false;

            }

        }


    }
}
