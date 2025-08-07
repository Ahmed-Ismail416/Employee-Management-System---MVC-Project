using AutoMapper;
using Business_Logic.DTOs.EmpoyeeDtos;
using DataAccess.Models.DepartmentModel;
using DataAccess.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department == null ? null : src.Department.Name));


            CreateMap<Employee, EmployeeDetailsDto>() // mapping gender to gneder and empoyeetype to employeetype
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department == null ? null : src.Department.Name));


            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<UpdatedEmployeeDto, Employee>()
            .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

        }
    }
}
