

using Demo.Data.Access.Models.DepartmentModel;

namespace Demo.Data.Access.Data.Configuration
{
    public class DepartmentConfiguration :BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Name).HasColumnType("nvarchar(30)");
         
            builder.Property(D => D.Code).HasColumnType("nvarchar(20)");
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);   
            builder.HasMany(d => d.Employees).WithOne(E=>E.Department).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);

        }
    }
}
