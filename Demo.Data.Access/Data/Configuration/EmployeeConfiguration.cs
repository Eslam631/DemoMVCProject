using Demo.Data.Access.Models.EmployeeModel;
using Demo.Data.Access.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Access.Data.Configuration
{
  public class EmployeeConfiguration :BaseEntityConfiguration<Employee> ,IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)");
            builder.Property(E => E.Address).HasColumnType("nvarchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E=>E.EmployeeType).HasConversion((EmpType)=>EmpType.ToString(),
                (EmpEnum)=>(EmployeeType) Enum.Parse(typeof(EmployeeType),EmpEnum) );
            builder.Property(E => E.Gender).HasConversion((EmpGender) => EmpGender.ToString(),
     (EmpEnum) => (Gender)Enum.Parse(typeof(Gender), EmpEnum));

            base.Configure(builder);

        }
    }
}
