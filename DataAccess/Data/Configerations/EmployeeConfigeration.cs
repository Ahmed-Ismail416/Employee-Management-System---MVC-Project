using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configerations
{
    public class EmployeeConfigeration : BaseEntityConfiguration<Employee>,IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // name varchar(50), address varchar(150) , salary decimal 10,2 , Gender hasconversion, 
            builder.Property(e => e.Id).UseIdentityColumn(10, increment: 10);
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender)
                   .HasConversion(EmpGender => EmpGender.ToString(),
                    gender => (Gender) Enum.Parse(typeof(Gender), gender));
            builder.Property(e => e.EmployeeType)
                   .HasConversion(emptype => emptype.ToString(),
                     _emptype => (EmployeeType)Enum.Parse(typeof(EmployeeType), _emptype));
            base.Configure(builder);
        }
    }
}
