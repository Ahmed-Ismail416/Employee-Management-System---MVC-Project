using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.DepartmentModel
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!; 
        public string Code { get; set; } = null!;
        public string? Discription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
