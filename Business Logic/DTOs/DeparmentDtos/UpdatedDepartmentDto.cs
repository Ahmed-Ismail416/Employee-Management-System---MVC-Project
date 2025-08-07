using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTOs
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Not null
        public string Code { get; set; } = string.Empty;
        public string? Discription { get; set; }
        public DateOnly DateOfCreation { get; set; } // This is the date when the department was created

    }
}
