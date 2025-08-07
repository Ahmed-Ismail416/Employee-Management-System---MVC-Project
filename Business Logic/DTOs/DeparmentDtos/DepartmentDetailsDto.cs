using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTOs
{
    public  class DepartmentDetailViewModel
    {
        public int Id { get; set; } //PK
        public int CreatedBy { get; set; } // User Id
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User Id
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } // Soft Delete

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Discription { get; set; }
    }
}
