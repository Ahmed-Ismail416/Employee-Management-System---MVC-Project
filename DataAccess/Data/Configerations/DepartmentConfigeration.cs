namespace DataAccess.Data.Configerations
{
    public class DepartmentConfigeration :BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d=> d.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GetDate()");
            builder.HasMany(e => e.Employees)
                   .WithOne(d => d.Department)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull );
           
            base.Configure(builder);
        }
    }
}
