using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTOs
{
    public class CreatedDepartmentDto
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
        public string? Discription { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
