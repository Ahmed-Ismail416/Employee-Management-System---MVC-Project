using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTOs.EmpoyeeDtos
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        //name, age, address, salary , isactive, emial, password, phonenumber, hiringdate, gender, employeetype, xreatedby ,created on , lastmodifiedby, lastmodifiedon
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; } =null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int DepartmentId { get; set; }
        public string? Department { get; set; }
        public string? ImageName { get; set; }
    }
}
