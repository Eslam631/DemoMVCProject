

namespace Demo.Data.Access.Data.Configuration
{
   public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Name).HasColumnType("nvarchar(30)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDATE()");
            builder.Property(D => D.Code).HasColumnType("nvarchar(20)");
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);   
        }
    }
}
