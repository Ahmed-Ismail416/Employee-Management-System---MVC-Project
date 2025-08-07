using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configerations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            // created on and last modified on
            builder.Property(b => b.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(b => b.LastModifiedOn).HasComputedColumnSql("GetDate()");

        }
    }
}
