using DataAccess.Models.EmployeeModel;
using DataAccess.Models.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTOs.EmpoyeeDtos
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Can't Be Null")]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;

        [Range(22, 35)]
        public int Age { get; set; }

        
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public int DepartmentId { get; set; }
        public IFormFile Image { get; set; }
    }
}
