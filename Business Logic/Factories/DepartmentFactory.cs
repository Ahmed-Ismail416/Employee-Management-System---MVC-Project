using Business_Logic.DTOs;
using DataAccess.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Factories
{
    static  class DepartmentFactory
    {
        public static DepartmentDto DepartmentToDto(this Department d)
        {
            return new DepartmentDto()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Discription,
                DateOfCreation = DateOnly.FromDateTime(d.CreatedOn)
            };
        }

        public static DepartmentDetailViewModel DepartmentToDetailsDto(this Department d)
        {
            return new DepartmentDetailViewModel()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code
            };       
        }

        public static Department ToEntity(this CreatedDepartmentDto d)
        {
            return new Department()
            {
                Name = d.Name,
                Code = d.Code,
                Discription = d.Discription,
                CreatedOn = d.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto d)
        {
            return new Department()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Discription = d.Discription,
                CreatedOn = d.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
