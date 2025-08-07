using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EmployeeModel
{
    public class Employee : BaseEntity
    {
        // , name , age , address , salary, isactive, email, phonenumber, hiringdate, gender, employyetype
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public string? ImageName { get; set; }

    }
}
